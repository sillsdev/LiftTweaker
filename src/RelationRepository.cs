using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;


namespace Tweaker
{
    public class RelationRepository
    {
        private readonly LiftAccessor _accessor;

        public RelationRepository(LiftAccessor accessor)
        {
            _accessor = accessor;
        }


        public IEnumerable<Entry> SourceEntries()
        {
            foreach (XmlNode node in _accessor.Dom.SelectNodes("//entry[relation]"))
            {
                 yield return new Entry(_accessor, node);
            }           
        }
    }

    public class Entry
    {
        private readonly LiftAccessor _accessor;
        private readonly XmlNode _entryNode;


        public Entry(LiftAccessor accessor, XmlNode node)
        {
            _accessor = accessor;
            _entryNode = node;
            Id = node.GetAttributeString("id");
        }

        public string Id { get; set; }
        public override string ToString()
        {
            //return _accessor.GetEntryFromId(Id);
            return GetEntryForm();
        }

        public XmlNode Node
        {
            get
            {
              //  return (_accessor.Dom.SelectSingleNode("//entry[@id='" + Id + "']"));
                return _entryNode;
            }
        }

        public IEnumerable<Relation> Relations()
        {
            foreach (XmlNode relation in Node.SelectNodes("relation"))
            {
                yield return new Relation(_accessor, this, relation);
            }
        }

        public string GetEntryForm()
        {
            var nodes = _entryNode.SelectNodes("lexical-unit/form/text");
            if (nodes == null || nodes.Count == 0)
                return "EntryNotFound";
            else
            {

                return nodes[0].InnerText;
            }
        }

    }

    public class Relation
    {
        private readonly LiftAccessor _accessor;
        private Entry Source { get; set;}
        private readonly XmlNode _relationNode;


        public Relation(LiftAccessor accessor, Entry source, XmlNode relationNode)
        {
            _accessor = accessor;
            Source = source;
            _relationNode = relationNode;
        }


        public string To
        {
            get
            {
                return _accessor.GetEntryFromId(TargetId);
            }
        }

        public string Type
        {
            get { return _relationNode.GetAttributeString("type"); }
        }

        public string SourceId
        {
            get { return Source.Id; }
        }

        public string TargetId
        {
            get { return _relationNode.GetAttributeString("ref"); }
        }
    }
}

