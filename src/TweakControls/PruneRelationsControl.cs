using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Tweaker
{
    public partial class PruneRelationsControl : UserControl
    {
        private readonly RelationRepository _relationRepository;
        private readonly PruneRelationCollection _pruneRelationRepo;

        public PruneRelationsControl(RelationRepository relationRepository, PruneRelationCollection pruneRelationRepo)
        {
            _relationRepository = relationRepository;
            _pruneRelationRepo = pruneRelationRepo;
            InitializeComponent();
        }

        private string GetGroupLabelForDisplay(string relationType)
        {
            switch (relationType)
            {
                case "minorentry":
                    return "See minor entry:";
                case "main":
                    return "See main entry:";
                case "See also":
                    return "See also:";
                case "subentry":
                    return "Include as subentry:";
                default:
                    return relationType;
            }
        }

        private void OnLoad(object sender, EventArgs e)
        {
            _sourceEntryList.SuspendLayout();
            _sourceEntryList.Sorted = true;
            _sourceEntryList.Items.Clear();
            
            _sourceEntryList.Items.AddRange(_relationRepository.SourceEntries().ToArray());
            if(_sourceEntryList.Items.Count>0)
                _sourceEntryList.SelectedIndex = 0;

            _sourceEntryList.ResumeLayout();
            _splitContainer.Panel1.BackColor = Parent.BackColor;
            _splitContainer.Panel2.BackColor = Parent.BackColor;
            _targetTable.BackColor = Parent.BackColor;
            //BackColor = Parent.BackColor;

        }

        private void _sourceEntryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            _targetTable.SuspendLayout();
            _targetTable.Controls.Clear();
            _targetTable.RowStyles.Clear();
            var groupedByRelationType = from r in CurrentSource.Relations() group r by r.Type;
            foreach (var grouping in groupedByRelationType)
            {
                Label header = new Label() { Text = GetGroupLabelForDisplay(grouping.Key )};
                header.TabIndex = _targetTable.RowCount;
                header.Padding = new Padding(0, 10, 0, 0);
                header.Dock = DockStyle.Fill;
                header.Height = 35;

                _targetTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                _targetTable.Controls.Add(header);
                foreach (var relation in grouping)
                {
                    var box = new RelationCheckBox((pr) => !_pruneRelationRepo.GetIsPruned(pr),
                        (isChecked, pr) => _pruneRelationRepo.SetIsPruned(pr, !isChecked),
                        new PruneRelation(relation.Type, relation.SourceId, relation.TargetId));
                    box.Width = 200;
                    box.TabIndex = _targetTable.RowCount;
                    box.Text = relation.To;
                    box.Padding = new Padding(20, 0, 0, 0);
                    

                    _targetTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    _targetTable.Controls.Add(box);
                }
            }
            _targetTable.ResumeLayout();
            
        }
        class RelationCheckBox : CheckBox
        {
            private readonly Func<PruneRelation, bool> _getValueFunction;
            private readonly Action<bool, PruneRelation> _actionWhenChanged;
            private readonly PruneRelation _relation;

            public RelationCheckBox(Func<PruneRelation, bool> getValueFunction,
                                       Action<bool, PruneRelation> actionWhenChanged, 
                                       PruneRelation relation)
            {
                _getValueFunction = getValueFunction;

                _actionWhenChanged = actionWhenChanged;
                _relation = relation;
                Checked = _getValueFunction.Invoke(_relation);
            }

            protected override void OnCheckedChanged(EventArgs e)
            {
                base.OnCheckedChanged(e);
                _actionWhenChanged.Invoke(Checked, _relation);
            }
        }

        private Entry CurrentSource
        {
            get { return _sourceEntryList.SelectedItem as Entry; }
        }
    }
}
