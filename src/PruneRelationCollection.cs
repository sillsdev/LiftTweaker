using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Linq;

namespace Tweaker
{
    [Serializable]
    public class PruneRelationCollection 
    {
        private List<PruneRelation> _prunes = new List<PruneRelation>();


        public List<PruneRelation> Prunes
        {
            get { return _prunes; }
            set { _prunes = value; }
        }

        public bool GetIsPruned(PruneRelation relation)
        {
            IEnumerable<PruneRelation> x = GetMatches(relation);
            return x.Count() > 0;
        }

        private IEnumerable<PruneRelation> GetMatches(PruneRelation relation)
        {
            return from prune in Prunes
                   where prune.relationType == relation.relationType
                         && prune.fromId == relation.fromId
                         && prune.toId == relation.toId
                   select prune;
        }

        public void SetIsPruned(PruneRelation relation, bool isPruned)
        {
            var x = GetMatches(relation);
            if (x.Count() >0)
                Prunes.Remove(x.First());//todo (well there shouldn't ever be more than 1)
            
            if (isPruned)
            {
                Prunes.Add(relation);
            }

        }

        public bool Contains(PruneRelation relation)
        {
            return GetMatches(relation).Count() > 0;
        }
    }

    [Serializable]
    public class PruneRelation
    {
        //capitalization is weird here to control xml tags (there's probably some
        //way I haven't found to override the xml tag so you can name the properties
        //what you like.
        public string relationType {get;set;}
        public string fromId { get; set; }
        public string toId { get; set; }

        //for deserialization
        protected PruneRelation()
        {
            
        }
        public PruneRelation(string relationTag, string from, string to)
        {
            relationType = relationTag;
            fromId = from;
            toId = to;
        }

        public static PruneRelation Create(XmlNode liftRelationNode)
        {
            XmlNode parentEntry = liftRelationNode.SelectSingleNode("ancestor::entry");
            string targetId = liftRelationNode.GetAttributeString("ref");
            string relationType = liftRelationNode.GetAttributeString("type");

            return new PruneRelation(relationType, parentEntry.GetAttributeString("id"), targetId);
        }
    }
}
