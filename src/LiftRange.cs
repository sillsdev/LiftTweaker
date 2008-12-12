using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Tweaker
{
    public class LiftRange : IEnumerable<LiftRangeItem>
    {
        private readonly string _rangeName;
        private XmlDocument _dom;

        public LiftRange(string pathToLift, string rangeName)
        {
            _rangeName = rangeName;
            var s  = pathToLift+"-ranges";
            if(!File.Exists(s))
            {
                MessageBox.Show(string.Format("Could not find a file of 'ranges', which FLEx exports. Was looking for {0}.  You can still tweak other things in the lift file.", s));
            }
            else
            {           
                _dom = new XmlDocument();
               _dom.Load(s);
            }

        }

        public IEnumerator<LiftRangeItem> GetEnumerator()
        {
            if(_dom ==null)
                yield break;

            foreach (XmlNode node in _dom.SelectNodes("//range[@id='"+_rangeName+"']/range-element"))
            {
                yield return new LiftRangeItem(node);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class LiftRangeItem
    {
        private readonly XmlNode _node;

        public LiftRangeItem(XmlNode node)
        {
            _node = node;
        }

        public string Label
        {
            get
            {
                var node = _node.SelectSingleNode("label/form[@lang='en']/text");
                if (node == null)
                    return "(empty)";
                return node.InnerText;
            }
        }
        public string Abbreviation
        {
            get
            {
                var node = _node.SelectSingleNode("abbrev/form[@lang='en']/text");
                if (node == null)
                    return "(empty)";
                return node.InnerText;
            }
        }

        public string Id
        {
            get
            {
                return _node.GetAttributeString("id");
            }
        }
    }
}
