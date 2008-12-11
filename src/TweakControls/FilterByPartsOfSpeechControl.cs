using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Tweaker
{
    public partial class FilterByPartsOfSpeechControl : UserControl
    {
        private readonly LiftRange _partsOfSpeech;
        private readonly FilterRangeItemCollection _partsOfSpeechToFilter;

        public FilterByPartsOfSpeechControl(LiftRange partsOfSpeech, FilterRangeItemCollection partsOfSpeechToFilter)
        {
            _partsOfSpeech = partsOfSpeech;
            _partsOfSpeechToFilter = partsOfSpeechToFilter;
            InitializeComponent();
        }


        private void OnLoad(object sender, EventArgs e)
        {
            _targetTable.BackColor = Parent.BackColor;

            _targetTable.SuspendLayout();
            _targetTable.Controls.Clear();
            _targetTable.RowStyles.Clear();

            foreach (var LiftRangeItem in _partsOfSpeech)
            {
                var box = new PosCheckBox((pos) => !_partsOfSpeechToFilter.Contains(pos),
                    (isChecked, pos) => _partsOfSpeechToFilter.SetContains(pos, !isChecked),
                    LiftRangeItem)
                              {
                                  Width = 200,
                                  TabIndex = _targetTable.RowCount,
                                  Text = LiftRangeItem.Label,
                                  Padding = new Padding(20, 0, 0, 0)
                              };


                _targetTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                _targetTable.Controls.Add(box);
            }
            _targetTable.ResumeLayout();
        }
            
        }
        class PosCheckBox : CheckBox
        {
            private readonly Func<LiftRangeItem, bool> _getValueFunction;
            private readonly Action<bool, LiftRangeItem> _actionWhenChanged;
            private readonly LiftRangeItem _pos;

            public PosCheckBox(Func<LiftRangeItem, bool> getValueFunction,
                                       Action<bool, LiftRangeItem> actionWhenChanged,
                                       LiftRangeItem pos)
            {
                _getValueFunction = getValueFunction;

                _actionWhenChanged = actionWhenChanged;
                _pos = pos;
                Checked = _getValueFunction.Invoke(_pos);
            }

            protected override void OnCheckedChanged(EventArgs e)
            {
                base.OnCheckedChanged(e);
                _actionWhenChanged.Invoke(Checked, _pos);
            }
        }

       
}
