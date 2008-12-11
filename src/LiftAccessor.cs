using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace Tweaker
{
    public class LiftAccessor
    {
        private readonly string _pathToLift;
        private XmlDocument _dom;
        public LiftAccessor(string path)
        {
            _pathToLift = path;
            _dom = new XmlDocument();
            Dom.Load(path);
        }

        public XmlDocument Dom
        {
            get { return _dom; }
        }

        public string PathToDirectory
        {
            get { return Path.GetDirectoryName(_pathToLift); }
        }

        public string PathToLift
        {
            get { return _pathToLift; }
        }

        public string GetEntryFromId(string id)
        {
            var node =_dom.SelectSingleNode("//entry[@id='" + id + "']");
            if(node==null)
            {
                return "*" + id.Substring(0,  id.IndexOf('_'));
            }
            return GetEntryForm(node);
        }

        public string GetEntryForm(XmlNode entry)
        {
            var nodes = entry.SelectNodes("lexical-unit/form/text");
            if (nodes == null || nodes.Count ==0)
                return "EntryNotFound";
            else
            {
                
                return nodes[0].InnerText;
            }
        }

        public LiftRange GetRange(string rangeName)
        {
            return new LiftRange(_pathToLift, rangeName);
        }
    }
}
