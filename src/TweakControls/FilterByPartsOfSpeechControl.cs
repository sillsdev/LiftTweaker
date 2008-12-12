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
        private readonly LiftAccessor _liftAccessor;
        private readonly LiftRange _partsOfSpeech;
        private readonly FilterRangeItemCollection _partsOfSpeechToFilter;

        public FilterByPartsOfSpeechControl(LiftAccessor liftAccessor, LiftRange partsOfSpeech, FilterRangeItemCollection partsOfSpeechToFilter)
        {
            _liftAccessor = liftAccessor;
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

            var inUse = _liftAccessor.GetPartsOfSpeechInUse();
            List<string> itemsToShow = new List<string>(inUse);
            itemsToShow.Add(FilterRangeItemCollection.MissingItemMatcher.Id);

            foreach (var rangeItemId in itemsToShow)
            {
                var box = new PosCheckBox((pos) => !_partsOfSpeechToFilter.Contains(pos),
                                          (isChecked, pos) => _partsOfSpeechToFilter.SetContains(pos, !isChecked),
                                          rangeItemId)
                              {
                                  Width =300,
                                  TabIndex = _targetTable.RowCount,
                                  Text = rangeItemId,//LiftRangeItem.Label,
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
            private readonly Func<string, bool> _getValueFunction;
            private readonly Action<bool, string> _actionWhenChanged;
            private readonly string _rangeItemId;

            public PosCheckBox(Func<string, bool> getValueFunction,
                                       Action<bool, string> actionWhenChanged,
                                       string rangeItemId)
            {
                _getValueFunction = getValueFunction;

                _rangeItemId = rangeItemId;
                Checked = _getValueFunction.Invoke(_rangeItemId);
                //important to do this *after* settin gthe Checked value
                _actionWhenChanged = actionWhenChanged;
           }

            protected override void OnCheckedChanged(EventArgs e)
            {
                base.OnCheckedChanged(e);
                if (_actionWhenChanged != null) //initial setting event will have this null
                    _actionWhenChanged.Invoke(Checked, _rangeItemId);
            }
        }

       
}
