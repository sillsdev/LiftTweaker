using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Tweaker
{
    public class TweakProcess : IDisposable
    {
        private LiftAccessor _liftAccessor;
        private PruneRelationCollection _pruneRelationRepository;
        private FilterRangeItemCollection _partsOfSpeechToFilter;
        public string Name { get; set; }

        //for deserialization only
        private TweakProcess(){}

        //for new, blank setups
        private TweakProcess(string name, LiftAccessor liftAccessor)
        {
            _liftAccessor = liftAccessor;
            Name = name;
            _pruneRelationRepository = new PruneRelationCollection();
            _partsOfSpeechToFilter = new FilterRangeItemCollection();
        }

        public static TweakProcess Create(string name, LiftAccessor liftAccessor)
        {
            var path = GetPathToTweakFile(liftAccessor.PathToLift, name);

            if(File.Exists(path))
            {
                using (var reader = XmlTextReader.Create(path))
                {
                    var deserializer = new XmlSerializer(typeof(TweakProcess));
                    var t =  (TweakProcess) deserializer.Deserialize(reader);
                    Debug.Assert(t.PruneRelationCollection!=null);
                    t.InitializeAfterDeserialization(liftAccessor);
                    return t;

                }
            }
            else
            {
                var process = new TweakProcess(name, liftAccessor);
                return process;
           }
        }



        public PruneRelationCollection PruneRelationCollection
        {
            get { return _pruneRelationRepository; }
            set { _pruneRelationRepository = value; }
        }

        public string ApplyTweaksAndGivePathToTweakedLift()
        {
            Save();
            ApplyTweaks();
            return PathToOutputLift;
        }

        public void Dispose()
        {
            Save();
            ApplyTweaks();
        }

        private void ApplyTweaks()
        {
            var target = new XmlDocument();
            target.LoadXml(_liftAccessor.Dom.OuterXml);
            foreach (XmlNode entry in target.SelectNodes("//entry"))
            {

                foreach (XmlNode relation in entry.SelectNodes("descendant::relation"))
                {
                    var r = PruneRelation.Create(relation);
                    if(_pruneRelationRepository.Contains(r))
                    {
                        relation.ParentNode.RemoveChild(relation);
                    }
                }
                foreach (XmlNode sense in entry.SelectNodes("sense"))
                {
                    var pos = sense.SelectSingleNode("grammatical-info");
                    if(pos==null)
                        continue;

                    if (_partsOfSpeechToFilter.Contains(pos.GetAttributeString("value")))
                    {
                        sense.ParentNode.RemoveChild(sense);
                    }
                } 
                if(null == entry.SelectSingleNode("sense"))// all senses where trimmed
                {
                    entry.ParentNode.RemoveChild(entry);
                }
            }
            target.Save(PathToOutputLift);
        }

        private void Save()
        {
            XmlWriterSettings settings= new XmlWriterSettings();
            settings.Indent = true;
     
            //settings.NewLineHandling = NewLineHandling.Entitize;
            settings.Encoding = Encoding.UTF8;

            using (var writer = System.Xml.XmlTextWriter.Create(PathToTweakFile, settings))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(TweakProcess));
                serializer.Serialize(writer,this);
            }
        }

        private string PathToTweakFile
        {
            get {
                return GetPathToTweakFile(_liftAccessor.PathToLift, Name);
            }
        }

        private static string GetPathToTweakFile(string pathToLift, string name)
        {
            var pathWithoutDotLift = pathToLift.Substring(0,pathToLift.LastIndexOf(".lift"));
            return pathWithoutDotLift + "-" + name + ".liftTweaks";
        }

        private string PathToOutputLift
        {
            get
            {
                var pathWithoutDotLift = _liftAccessor.PathToLift.Substring(0,
                                                                            _liftAccessor.PathToLift.LastIndexOf(".lift"));
                return pathWithoutDotLift + "-" + Name + ".lift";
            }
        }

        public FilterRangeItemCollection PartsOfSpeechToFilter
        {
            get { return _partsOfSpeechToFilter; }
            set { _partsOfSpeechToFilter = value; }

        }

        private void InitializeAfterDeserialization(LiftAccessor accessor)
        {
            _liftAccessor = accessor;
        }
    }
}
