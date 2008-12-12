﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Autofac;

namespace Tweaker
{
    public partial class Shell : Form
    {
        private readonly string[] _args;
        private IContainer _sessionContainer;

        public Shell(string[] args)
        {
            _args = args;
            InitializeComponent();
            _areaTreeControl.LoadTweakControl +=(OnTweakControlChanged);
            _openInLexiqueProButton.Enabled = false;
        }


        void OnTweakControlChanged(object sender, Rhino.Commons.EventArgs<AreaTree.AreaFormCommand> e)
        {
            splitContainer1.Panel2.Controls.Clear();
            UserControl control = e.Item.ControlFactory.Invoke(_sessionContainer);
            control.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(control);
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            if(_sessionContainer !=null)
            {
                _sessionContainer.Dispose();
                _sessionContainer = null;
            }
            base.OnClosing(e);
        }
        private void OnOpenInLexiqueProButton_Click(object sender, EventArgs e)
        {
            OpenWithLexiqueProCommand cmd = _sessionContainer.Resolve(typeof(OpenWithLexiqueProCommand)) as OpenWithLexiqueProCommand;
             cmd.Execute();
        }

        private void OnChangedTargetChoice(object sender, EventArgs e)
        {
            if (_targetDocumentCombo.SelectedIndex > 0)
            {
                MessageBox.Show("Sorry, this doesn't actually do anything yet.");
                _targetDocumentCombo.SelectedIndex = 0;
            }
        }

        private void OnOpenLiftButton_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.CheckFileExists = true;
            dlg.Filter = "Lift Files(*.lift)|*.lift";
            dlg.AutoUpgradeEnabled = true;
            dlg.Title = "Open Lift File (WeSay or Export From FLEx)";
            
            if(System.Windows.Forms.DialogResult.OK != dlg.ShowDialog())
                return;
            
            if(dlg.FileName.Contains("-") )
            {
                int x = dlg.FileName.LastIndexOf("-");
                var s = dlg.FileName.Substring(0, x);
                if (File.Exists(s + ".lift"))
                {
                    MessageBox.Show(
                        string.Format(
                            "Oops.  {0} looks like it's an *output* of a previous run of this program.  Please instead choose an untweaked lift file.",
                            Path.GetFileName(dlg.FileName)));

                    return;
                }
            }
            OpenLiftFile(dlg.FileName);
        }

        private void OpenLiftFile(string path)
        {
            this.Text = "Lift Tweaker - " +path ;
            splitContainer1.Panel2.Controls.Clear();

            if(_sessionContainer!=null)
                _sessionContainer.Dispose();

            var builder = new Autofac.Builder.ContainerBuilder();
            builder.Register<OpenWithLexiqueProCommand>();
            builder.Register<LiftAccessor>(c => new LiftAccessor(path));
            builder.Register<TweakProcess>(c => TweakProcess.Create("normal", c.Resolve<LiftAccessor>()));
            builder.Register<RelationSource>();
            builder.Register<PruneRelationCollection>(c => c.Resolve<TweakProcess>().PruneRelationCollection);
            builder.Register<PruneRelationsControl>();


            builder.Register<LiftRange>(c => c.Resolve<LiftAccessor>().GetRange("grammatical-info"));
            builder.Register<FilterRangeItemCollection>(c => c.Resolve<TweakProcess>().PartsOfSpeechToFilter);
            builder.Register<FilterByPartsOfSpeechControl>();

            _sessionContainer = builder.Build();
            
            _areaTreeControl.LoadTweakChoices();

            _openInLexiqueProButton.Enabled = true;
        }


        private void Shell_Load(object sender, EventArgs e)
        {
            if(_args.Length > 0 && File.Exists(_args[0]))
                OpenLiftFile(_args[0]);//@"c:\lifttweaker\sample\sample.lift");

        }

        private void OnAbout(object sender, EventArgs e)
        {
            var dlg = new AboutBox();
            dlg.ShowDialog(this);
        }
    }

 
}
