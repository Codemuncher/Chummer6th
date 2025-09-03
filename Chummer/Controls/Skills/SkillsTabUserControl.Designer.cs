using System;

namespace Chummer.UI.Skills
{
    partial class SkillsTabUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitSkills = new SplitContainer();
            tlpTopPanel = new TableLayoutPanel();
            tlpSkills = new TableLayoutPanel();
            btnAddSkills = new Button();
            cboSkillList = new ComboBox();
            tlpActiveSkills = new TableLayoutPanel();
            lblActiveSp = new Label();
            lblActiveSkills = new Label();
            lblActiveKarma = new Label();
            lblBuyWithKarma = new Label();
            btnResetCustomDisplayAttribute = new Button();
            tlpActiveSkillsButtons = new TableLayoutPanel();
            btnExotic = new Button();
            cboSort = new ElasticComboBox();
            cboDisplayFilter = new ElasticComboBox();
            panel1 = new Panel();
            tlpBottomPanel = new TableLayoutPanel();
            lblKnoSp = new Label();
            lblKnowledgeSkills = new Label();
            lblKnoKarma = new Label();
            lblKnoBwk = new Label();
            lblCustomKnowledgeSkillsReminder = new Label();
            tlpKnowledgeSkillsHeader = new TableLayoutPanel();
            cboDisplayFilterKnowledge = new ElasticComboBox();
            cboSortKnowledge = new ElasticComboBox();
            btnKnowledge = new Button();
            lblKnowledgeSkillPoints = new Label();
            lblKnowledgeSkillPointsTitle = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            splitContainer1 = new SplitContainer();
            splitContainer2 = new SplitContainer();
            splitContainer3 = new SplitContainer();
            splitContainer4 = new SplitContainer();
            ((System.ComponentModel.ISupportInitialize)splitSkills).BeginInit();
            splitSkills.Panel1.SuspendLayout();
            splitSkills.Panel2.SuspendLayout();
            splitSkills.SuspendLayout();
            tlpTopPanel.SuspendLayout();
            tlpSkills.SuspendLayout();
            tlpActiveSkills.SuspendLayout();
            panel1.SuspendLayout();
            tlpBottomPanel.SuspendLayout();
            tlpKnowledgeSkillsHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer4).BeginInit();
            splitContainer4.Panel1.SuspendLayout();
            splitContainer4.Panel2.SuspendLayout();
            splitContainer4.SuspendLayout();
            SuspendLayout();
            // 
            // splitSkills
            // 
            splitSkills.BackColor = SystemColors.InactiveCaption;
            splitSkills.Dock = DockStyle.Fill;
            splitSkills.ForeColor = SystemColors.InactiveCaption;
            splitSkills.Location = new Point(0, 0);
            splitSkills.Margin = new Padding(0);
            splitSkills.Name = "splitSkills";
            splitSkills.Orientation = Orientation.Horizontal;
            // 
            // splitSkills.Panel1
            // 
            splitSkills.Panel1.BackColor = SystemColors.Control;
            splitSkills.Panel1.Controls.Add(tlpTopPanel);
            splitSkills.Panel1.ForeColor = SystemColors.ControlText;
            splitSkills.Panel1.Resize += Panel1_Resize;
            // 
            // splitSkills.Panel2
            // 
            splitSkills.Panel2.BackColor = SystemColors.Control;
            splitSkills.Panel2.Controls.Add(tlpBottomPanel);
            splitSkills.Panel2.ForeColor = SystemColors.ControlText;
            splitSkills.Panel2.Resize += Panel2_Resize;
            splitSkills.Size = new Size(800, 611);
            splitSkills.SplitterDistance = 452;
            splitSkills.TabIndex = 0;
            splitSkills.Resize += splitSkills_Resize;
            // 
            // tlpTopPanel
            // 
            tlpTopPanel.ColumnCount = 1;
            tlpTopPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpTopPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75F));
            tlpTopPanel.Controls.Add(tlpSkills, 0, 1);
            tlpTopPanel.Controls.Add(tlpActiveSkills, 0, 2);
            tlpTopPanel.Controls.Add(panel1, 0, 0);
            tlpTopPanel.Dock = DockStyle.Fill;
            tlpTopPanel.Location = new Point(0, 0);
            tlpTopPanel.Margin = new Padding(0);
            tlpTopPanel.Name = "tlpTopPanel";
            tlpTopPanel.RowCount = 3;
            tlpTopPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10.1265821F));
            tlpTopPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 89.87342F));
            tlpTopPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            tlpTopPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpTopPanel.Size = new Size(800, 452);
            tlpTopPanel.TabIndex = 58;
            // 
            // tlpSkills
            // 
            tlpSkills.ColumnCount = 5;
            tlpSkills.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 192F));
            tlpSkills.ColumnStyles.Add(new ColumnStyle());
            tlpSkills.ColumnStyles.Add(new ColumnStyle());
            tlpSkills.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpSkills.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 104F));
            tlpSkills.Controls.Add(btnExotic, 4, 0);
            tlpSkills.Controls.Add(lblActiveSkills, 0, 1);
            tlpSkills.Controls.Add(lblActiveSp, 1, 1);
            tlpSkills.Controls.Add(lblBuyWithKarma, 3, 1);
            tlpSkills.Controls.Add(lblActiveKarma, 2, 1);
            tlpSkills.Controls.Add(splitContainer2, 3, 0);
            tlpSkills.Dock = DockStyle.Fill;
            tlpSkills.Location = new Point(3, 43);
            tlpSkills.Name = "tlpSkills";
            tlpSkills.RowCount = 3;
            tlpSkills.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tlpSkills.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tlpSkills.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpSkills.Size = new Size(794, 349);
            tlpSkills.TabIndex = 3;
            // 
            // btnAddSkills
            // 
            btnAddSkills.AutoSize = true;
            btnAddSkills.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAddSkills.Dock = DockStyle.Fill;
            btnAddSkills.Location = new Point(0, 0);
            btnAddSkills.MinimumSize = new Size(80, 0);
            btnAddSkills.Name = "btnAddSkills";
            btnAddSkills.Size = new Size(87, 29);
            btnAddSkills.TabIndex = 1;
            btnAddSkills.Tag = "Button_AddSkill";
            btnAddSkills.Text = "&Add Skill";
            btnAddSkills.UseVisualStyleBackColor = true;
            btnAddSkills.Click += btnAddSkills_Click;
            // 
            // cboSkillList
            // 
            cboSkillList.FormattingEnabled = true;
            cboSkillList.Location = new Point(3, 3);
            cboSkillList.Name = "cboSkillList";
            cboSkillList.Size = new Size(303, 23);
            cboSkillList.TabIndex = 0;
            // 
            // tlpActiveSkills
            // 
            tlpActiveSkills.Anchor = AnchorStyles.None;
            tlpActiveSkills.ColumnCount = 5;
            tlpActiveSkills.ColumnStyles.Add(new ColumnStyle());
            tlpActiveSkills.ColumnStyles.Add(new ColumnStyle());
            tlpActiveSkills.ColumnStyles.Add(new ColumnStyle());
            tlpActiveSkills.ColumnStyles.Add(new ColumnStyle());
            tlpActiveSkills.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpActiveSkills.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tlpActiveSkills.Controls.Add(tlpActiveSkillsButtons, 1, 0);
            tlpActiveSkills.Location = new Point(9, 395);
            tlpActiveSkills.Margin = new Padding(9, 0, 0, 0);
            tlpActiveSkills.Name = "tlpActiveSkills";
            tlpActiveSkills.RowCount = 3;
            tlpActiveSkills.RowStyles.Add(new RowStyle());
            tlpActiveSkills.RowStyles.Add(new RowStyle());
            tlpActiveSkills.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpActiveSkills.Size = new Size(791, 57);
            tlpActiveSkills.TabIndex = 57;
            // 
            // lblActiveSp
            // 
            lblActiveSp.AutoSize = true;
            lblActiveSp.Dock = DockStyle.Bottom;
            lblActiveSp.Location = new Point(195, 45);
            lblActiveSp.Name = "lblActiveSp";
            lblActiveSp.Size = new Size(40, 15);
            lblActiveSp.TabIndex = 46;
            lblActiveSp.Tag = "String_Points";
            lblActiveSp.Text = "Points";
            lblActiveSp.TextAlign = ContentAlignment.BottomLeft;
            // 
            // lblActiveSkills
            // 
            lblActiveSkills.AutoSize = true;
            lblActiveSkills.Dock = DockStyle.Bottom;
            lblActiveSkills.Location = new Point(3, 38);
            lblActiveSkills.MinimumSize = new Size(0, 22);
            lblActiveSkills.Name = "lblActiveSkills";
            lblActiveSkills.Size = new Size(186, 22);
            lblActiveSkills.TabIndex = 3;
            lblActiveSkills.Tag = "Label_ActiveSkills";
            lblActiveSkills.Text = "Active Skills";
            lblActiveSkills.TextAlign = ContentAlignment.BottomLeft;
            // 
            // lblActiveKarma
            // 
            lblActiveKarma.AutoSize = true;
            lblActiveKarma.Dock = DockStyle.Bottom;
            lblActiveKarma.Location = new Point(241, 45);
            lblActiveKarma.Name = "lblActiveKarma";
            lblActiveKarma.Size = new Size(41, 15);
            lblActiveKarma.TabIndex = 47;
            lblActiveKarma.Tag = "String_Karma";
            lblActiveKarma.Text = "Karma";
            lblActiveKarma.TextAlign = ContentAlignment.BottomLeft;
            // 
            // lblBuyWithKarma
            // 
            lblBuyWithKarma.AutoSize = true;
            lblBuyWithKarma.Dock = DockStyle.Bottom;
            lblBuyWithKarma.Location = new Point(288, 45);
            lblBuyWithKarma.Name = "lblBuyWithKarma";
            lblBuyWithKarma.Size = new Size(399, 15);
            lblBuyWithKarma.TabIndex = 50;
            lblBuyWithKarma.Tag = "String_BuyWithKarma";
            lblBuyWithKarma.Text = "Buy With Karma";
            lblBuyWithKarma.TextAlign = ContentAlignment.BottomRight;
            // 
            // btnResetCustomDisplayAttribute
            // 
            btnResetCustomDisplayAttribute.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnResetCustomDisplayAttribute.AutoSize = true;
            btnResetCustomDisplayAttribute.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnResetCustomDisplayAttribute.Location = new Point(2, 4);
            btnResetCustomDisplayAttribute.Margin = new Padding(0);
            btnResetCustomDisplayAttribute.MinimumSize = new Size(80, 0);
            btnResetCustomDisplayAttribute.Name = "btnResetCustomDisplayAttribute";
            btnResetCustomDisplayAttribute.Size = new Size(80, 25);
            btnResetCustomDisplayAttribute.TabIndex = 53;
            btnResetCustomDisplayAttribute.Tag = "Button_ResetAll";
            btnResetCustomDisplayAttribute.Text = "Reset All";
            btnResetCustomDisplayAttribute.UseVisualStyleBackColor = true;
            btnResetCustomDisplayAttribute.Visible = false;
            btnResetCustomDisplayAttribute.Click += btnResetCustomDisplayAttribute_Click;
            // 
            // tlpActiveSkillsButtons
            // 
            tlpActiveSkillsButtons.AutoSize = true;
            tlpActiveSkillsButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpActiveSkillsButtons.ColumnCount = 3;
            tlpActiveSkills.SetColumnSpan(tlpActiveSkillsButtons, 4);
            tlpActiveSkillsButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40.19608F));
            tlpActiveSkillsButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 59.80392F));
            tlpActiveSkillsButtons.ColumnStyles.Add(new ColumnStyle());
            tlpActiveSkillsButtons.Dock = DockStyle.Fill;
            tlpActiveSkillsButtons.Location = new Point(0, 0);
            tlpActiveSkillsButtons.Margin = new Padding(0);
            tlpActiveSkillsButtons.Name = "tlpActiveSkillsButtons";
            tlpActiveSkillsButtons.RowCount = 1;
            tlpActiveSkillsButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpActiveSkillsButtons.Size = new Size(791, 1);
            tlpActiveSkillsButtons.TabIndex = 53;
            // 
            // btnExotic
            // 
            btnExotic.Anchor = AnchorStyles.Right;
            btnExotic.AutoSize = true;
            btnExotic.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnExotic.Location = new Point(694, 5);
            btnExotic.MinimumSize = new Size(80, 0);
            btnExotic.Name = "btnExotic";
            btnExotic.Size = new Size(97, 25);
            btnExotic.TabIndex = 2;
            btnExotic.Tag = "Button_AddExoticSkill";
            btnExotic.Text = "Add Exotic Skill";
            btnExotic.UseVisualStyleBackColor = true;
            btnExotic.Click += btnExotic_Click;
            // 
            // cboSort
            // 
            cboSort.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSort.FormattingEnabled = true;
            cboSort.IntegralHeight = false;
            cboSort.Location = new Point(4, 3);
            cboSort.Name = "cboSort";
            cboSort.Size = new Size(281, 23);
            cboSort.TabIndex = 4;
            cboSort.SelectedIndexChanged += cboSort_SelectedIndexChanged;
            // 
            // cboDisplayFilter
            // 
            cboDisplayFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDisplayFilter.FormattingEnabled = true;
            cboDisplayFilter.IntegralHeight = false;
            cboDisplayFilter.Location = new Point(3, 3);
            cboDisplayFilter.Name = "cboDisplayFilter";
            cboDisplayFilter.Size = new Size(399, 23);
            cboDisplayFilter.TabIndex = 1;
            cboDisplayFilter.SelectedIndexChanged += cboDisplayFilter_SelectedIndexChanged;
            cboDisplayFilter.TextUpdate += cboDisplayFilter_TextUpdate;
            // 
            // panel1
            // 
            panel1.Controls.Add(splitContainer3);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(793, 34);
            panel1.TabIndex = 58;
            // 
            // tlpBottomPanel
            // 
            tlpBottomPanel.AutoSize = true;
            tlpBottomPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpBottomPanel.ColumnCount = 4;
            tlpBottomPanel.ColumnStyles.Add(new ColumnStyle());
            tlpBottomPanel.ColumnStyles.Add(new ColumnStyle());
            tlpBottomPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpBottomPanel.ColumnStyles.Add(new ColumnStyle());
            tlpBottomPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tlpBottomPanel.Controls.Add(lblKnoSp, 1, 1);
            tlpBottomPanel.Controls.Add(lblKnowledgeSkills, 0, 1);
            tlpBottomPanel.Controls.Add(lblKnoKarma, 2, 1);
            tlpBottomPanel.Controls.Add(lblKnoBwk, 3, 1);
            tlpBottomPanel.Controls.Add(lblCustomKnowledgeSkillsReminder, 0, 3);
            tlpBottomPanel.Controls.Add(tlpKnowledgeSkillsHeader, 0, 0);
            tlpBottomPanel.Dock = DockStyle.Fill;
            tlpBottomPanel.Location = new Point(0, 0);
            tlpBottomPanel.Margin = new Padding(0);
            tlpBottomPanel.Name = "tlpBottomPanel";
            tlpBottomPanel.RowCount = 4;
            tlpBottomPanel.RowStyles.Add(new RowStyle());
            tlpBottomPanel.RowStyles.Add(new RowStyle());
            tlpBottomPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpBottomPanel.RowStyles.Add(new RowStyle());
            tlpBottomPanel.Size = new Size(800, 155);
            tlpBottomPanel.TabIndex = 59;
            // 
            // lblKnoSp
            // 
            lblKnoSp.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblKnoSp.AutoSize = true;
            lblKnoSp.Location = new Point(104, 38);
            lblKnoSp.Name = "lblKnoSp";
            lblKnoSp.Size = new Size(40, 15);
            lblKnoSp.TabIndex = 53;
            lblKnoSp.Tag = "String_Points";
            lblKnoSp.Text = "Points";
            lblKnoSp.TextAlign = ContentAlignment.BottomLeft;
            // 
            // lblKnowledgeSkills
            // 
            lblKnowledgeSkills.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblKnowledgeSkills.AutoSize = true;
            lblKnowledgeSkills.Location = new Point(3, 31);
            lblKnowledgeSkills.MinimumSize = new Size(0, 22);
            lblKnowledgeSkills.Name = "lblKnowledgeSkills";
            lblKnowledgeSkills.Size = new Size(95, 22);
            lblKnowledgeSkills.TabIndex = 4;
            lblKnowledgeSkills.Tag = "Label_KnowledgeSkills";
            lblKnowledgeSkills.Text = "Knowledge Skills";
            lblKnowledgeSkills.TextAlign = ContentAlignment.BottomLeft;
            // 
            // lblKnoKarma
            // 
            lblKnoKarma.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblKnoKarma.AutoSize = true;
            lblKnoKarma.Location = new Point(150, 38);
            lblKnoKarma.Name = "lblKnoKarma";
            lblKnoKarma.Size = new Size(41, 15);
            lblKnoKarma.TabIndex = 54;
            lblKnoKarma.Tag = "String_Karma";
            lblKnoKarma.Text = "Karma";
            lblKnoKarma.TextAlign = ContentAlignment.BottomLeft;
            // 
            // lblKnoBwk
            // 
            lblKnoBwk.Anchor = AnchorStyles.Bottom;
            lblKnoBwk.AutoSize = true;
            lblKnoBwk.Location = new Point(705, 38);
            lblKnoBwk.Name = "lblKnoBwk";
            lblKnoBwk.Size = new Size(92, 15);
            lblKnoBwk.TabIndex = 53;
            lblKnoBwk.Tag = "String_BuyWithKarma";
            lblKnoBwk.Text = "Buy With Karma";
            lblKnoBwk.TextAlign = ContentAlignment.BottomRight;
            // 
            // lblCustomKnowledgeSkillsReminder
            // 
            lblCustomKnowledgeSkillsReminder.Anchor = AnchorStyles.Bottom;
            lblCustomKnowledgeSkillsReminder.AutoSize = true;
            tlpBottomPanel.SetColumnSpan(lblCustomKnowledgeSkillsReminder, 4);
            lblCustomKnowledgeSkillsReminder.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCustomKnowledgeSkillsReminder.Location = new Point(201, 136);
            lblCustomKnowledgeSkillsReminder.Margin = new Padding(3, 6, 3, 6);
            lblCustomKnowledgeSkillsReminder.Name = "lblCustomKnowledgeSkillsReminder";
            lblCustomKnowledgeSkillsReminder.Size = new Size(398, 13);
            lblCustomKnowledgeSkillsReminder.TabIndex = 55;
            lblCustomKnowledgeSkillsReminder.Tag = "Label_CustomKnowledgeSkillsReminder";
            lblCustomKnowledgeSkillsReminder.Text = "Remember, you can always write in custom skills and specializations!";
            lblCustomKnowledgeSkillsReminder.TextAlign = ContentAlignment.BottomCenter;
            // 
            // tlpKnowledgeSkillsHeader
            // 
            tlpKnowledgeSkillsHeader.AutoSize = true;
            tlpKnowledgeSkillsHeader.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpKnowledgeSkillsHeader.ColumnCount = 5;
            tlpBottomPanel.SetColumnSpan(tlpKnowledgeSkillsHeader, 4);
            tlpKnowledgeSkillsHeader.ColumnStyles.Add(new ColumnStyle());
            tlpKnowledgeSkillsHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tlpKnowledgeSkillsHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tlpKnowledgeSkillsHeader.ColumnStyles.Add(new ColumnStyle());
            tlpKnowledgeSkillsHeader.ColumnStyles.Add(new ColumnStyle());
            tlpKnowledgeSkillsHeader.Controls.Add(cboDisplayFilterKnowledge, 2, 0);
            tlpKnowledgeSkillsHeader.Controls.Add(cboSortKnowledge, 1, 0);
            tlpKnowledgeSkillsHeader.Controls.Add(btnKnowledge, 0, 0);
            tlpKnowledgeSkillsHeader.Controls.Add(lblKnowledgeSkillPoints, 4, 0);
            tlpKnowledgeSkillsHeader.Controls.Add(lblKnowledgeSkillPointsTitle, 3, 0);
            tlpKnowledgeSkillsHeader.Dock = DockStyle.Fill;
            tlpKnowledgeSkillsHeader.Location = new Point(0, 0);
            tlpKnowledgeSkillsHeader.Margin = new Padding(0);
            tlpKnowledgeSkillsHeader.Name = "tlpKnowledgeSkillsHeader";
            tlpKnowledgeSkillsHeader.RowCount = 1;
            tlpKnowledgeSkillsHeader.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpKnowledgeSkillsHeader.Size = new Size(800, 31);
            tlpKnowledgeSkillsHeader.TabIndex = 60;
            // 
            // cboDisplayFilterKnowledge
            // 
            cboDisplayFilterKnowledge.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboDisplayFilterKnowledge.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDisplayFilterKnowledge.FormattingEnabled = true;
            cboDisplayFilterKnowledge.IntegralHeight = false;
            cboDisplayFilterKnowledge.Location = new Point(269, 4);
            cboDisplayFilterKnowledge.Name = "cboDisplayFilterKnowledge";
            cboDisplayFilterKnowledge.Size = new Size(265, 23);
            cboDisplayFilterKnowledge.TabIndex = 54;
            cboDisplayFilterKnowledge.SelectedIndexChanged += cboDisplayFilterKnowledge_SelectedIndexChanged;
            cboDisplayFilterKnowledge.TextUpdate += cboDisplayFilterKnowledge_TextUpdate;
            // 
            // cboSortKnowledge
            // 
            cboSortKnowledge.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboSortKnowledge.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSortKnowledge.FormattingEnabled = true;
            cboSortKnowledge.IntegralHeight = false;
            cboSortKnowledge.Location = new Point(89, 4);
            cboSortKnowledge.Name = "cboSortKnowledge";
            cboSortKnowledge.Size = new Size(174, 23);
            cboSortKnowledge.TabIndex = 55;
            cboSortKnowledge.SelectedIndexChanged += cboSortKnowledge_SelectedIndexChanged;
            // 
            // btnKnowledge
            // 
            btnKnowledge.Anchor = AnchorStyles.Left;
            btnKnowledge.AutoSize = true;
            btnKnowledge.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnKnowledge.Location = new Point(3, 3);
            btnKnowledge.MinimumSize = new Size(80, 0);
            btnKnowledge.Name = "btnKnowledge";
            btnKnowledge.Size = new Size(80, 25);
            btnKnowledge.TabIndex = 0;
            btnKnowledge.Tag = "Button_AddSkill";
            btnKnowledge.Text = "&Add Skill";
            btnKnowledge.UseVisualStyleBackColor = true;
            btnKnowledge.Click += btnKnowledge_Click;
            // 
            // lblKnowledgeSkillPoints
            // 
            lblKnowledgeSkillPoints.Anchor = AnchorStyles.Left;
            lblKnowledgeSkillPoints.AutoSize = true;
            lblKnowledgeSkillPoints.Location = new Point(760, 8);
            lblKnowledgeSkillPoints.Margin = new Padding(3, 6, 3, 6);
            lblKnowledgeSkillPoints.Name = "lblKnowledgeSkillPoints";
            lblKnowledgeSkillPoints.Size = new Size(36, 15);
            lblKnowledgeSkillPoints.TabIndex = 38;
            lblKnowledgeSkillPoints.Text = "0 of 0";
            lblKnowledgeSkillPoints.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblKnowledgeSkillPointsTitle
            // 
            lblKnowledgeSkillPointsTitle.Anchor = AnchorStyles.Right;
            lblKnowledgeSkillPointsTitle.AutoSize = true;
            lblKnowledgeSkillPointsTitle.Location = new Point(540, 8);
            lblKnowledgeSkillPointsTitle.Margin = new Padding(3, 6, 3, 6);
            lblKnowledgeSkillPointsTitle.Name = "lblKnowledgeSkillPointsTitle";
            lblKnowledgeSkillPointsTitle.Size = new Size(214, 15);
            lblKnowledgeSkillPointsTitle.TabIndex = 37;
            lblKnowledgeSkillPointsTitle.Tag = "Label_FreeKnowledgeSkills";
            lblKnowledgeSkillPointsTitle.Text = "Free Knowledge Skill Points Remaining:";
            lblKnowledgeSkillPointsTitle.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Size = new Size(200, 100);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(3, 3);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Size = new Size(379, 40);
            splitContainer1.SplitterDistance = 256;
            splitContainer1.TabIndex = 2;
            // 
            // splitContainer2
            // 
            splitContainer2.Location = new Point(288, 3);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(cboSkillList);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(btnAddSkills);
            splitContainer2.Size = new Size(399, 29);
            splitContainer2.SplitterDistance = 308;
            splitContainer2.TabIndex = 51;
            // 
            // splitContainer3
            // 
            splitContainer3.Dock = DockStyle.Fill;
            splitContainer3.Location = new Point(0, 0);
            splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.Controls.Add(cboSort);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(splitContainer4);
            splitContainer3.Size = new Size(793, 34);
            splitContainer3.SplitterDistance = 287;
            splitContainer3.TabIndex = 0;
            // 
            // splitContainer4
            // 
            splitContainer4.Dock = DockStyle.Fill;
            splitContainer4.Location = new Point(0, 0);
            splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            splitContainer4.Panel1.Controls.Add(cboDisplayFilter);
            // 
            // splitContainer4.Panel2
            // 
            splitContainer4.Panel2.Controls.Add(btnResetCustomDisplayAttribute);
            splitContainer4.Size = new Size(502, 34);
            splitContainer4.SplitterDistance = 405;
            splitContainer4.TabIndex = 0;
            // 
            // SkillsTabUserControl
            // 
            Controls.Add(splitSkills);
            DoubleBuffered = true;
            Name = "SkillsTabUserControl";
            Size = new Size(800, 611);
            Load += SkillsTabUserControl_Load;
            splitSkills.Panel1.ResumeLayout(false);
            splitSkills.Panel2.ResumeLayout(false);
            splitSkills.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitSkills).EndInit();
            splitSkills.ResumeLayout(false);
            tlpTopPanel.ResumeLayout(false);
            tlpSkills.ResumeLayout(false);
            tlpSkills.PerformLayout();
            tlpActiveSkills.ResumeLayout(false);
            tlpActiveSkills.PerformLayout();
            panel1.ResumeLayout(false);
            tlpBottomPanel.ResumeLayout(false);
            tlpBottomPanel.PerformLayout();
            tlpKnowledgeSkillsHeader.ResumeLayout(false);
            tlpKnowledgeSkillsHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            splitContainer4.Panel1.ResumeLayout(false);
            splitContainer4.Panel2.ResumeLayout(false);
            splitContainer4.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer4).EndInit();
            splitContainer4.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitSkills;
        private System.Windows.Forms.Button btnKnowledge;
        private System.Windows.Forms.Label lblActiveSkills;
        private System.Windows.Forms.Label lblKnowledgeSkillPoints;
        private System.Windows.Forms.Label lblKnowledgeSkillPointsTitle;
        private System.Windows.Forms.Label lblKnowledgeSkills;
        private System.Windows.Forms.Label lblBuyWithKarma;
        private System.Windows.Forms.Label lblActiveKarma;
        private System.Windows.Forms.Label lblActiveSp;
        private System.Windows.Forms.Label lblKnoKarma;
        private System.Windows.Forms.Label lblKnoSp;
        private System.Windows.Forms.Label lblKnoBwk;
        private System.Windows.Forms.Button btnResetCustomDisplayAttribute;
        private System.Windows.Forms.Label lblCustomKnowledgeSkillsReminder;
        private ElasticComboBox cboSortKnowledge;
        private ElasticComboBox cboDisplayFilterKnowledge;
        private System.Windows.Forms.TableLayoutPanel tlpActiveSkills;
        private System.Windows.Forms.TableLayoutPanel tlpTopPanel;
        private System.Windows.Forms.TableLayoutPanel tlpBottomPanel;
        private System.Windows.Forms.TableLayoutPanel tlpKnowledgeSkillsHeader;
        private System.Windows.Forms.TableLayoutPanel tlpActiveSkillsButtons;
        private ElasticComboBox cboSort;
        private ElasticComboBox cboDisplayFilter;
        private System.Windows.Forms.Button btnExotic;
        private TableLayoutPanel tableLayoutPanel1;
        private SplitContainer splitContainer1;
        private ComboBox cboSkillList;
        private Table.TextTableCell textTableCell1;
        private TableLayoutPanel tlpSkills;
        private Button btnAddSkills;
        private Panel panel1;
        private SplitContainer splitContainer2;
        private SplitContainer splitContainer3;
        private SplitContainer splitContainer4;
    }
}
