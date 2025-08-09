namespace Chummer
{
    partial class SelectMetatypePriority
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectMetatypePriority));
            cboCategory = new ElasticComboBox();
            cmdCancel = new Button();
            lblMetavariantQualities = new Label();
            cboMetavariant = new ElasticComboBox();
            cmdOK = new Button();
            lblWILLabel = new Label();
            lblWIL = new Label();
            lblLOGLabel = new Label();
            lblLOG = new Label();
            lblINTLabel = new Label();
            lblINT = new Label();
            lblCHALabel = new Label();
            lblCHA = new Label();
            lblSTR = new Label();
            lblSTRLabel = new Label();
            lblREA = new Label();
            lblREALabel = new Label();
            lblAGI = new Label();
            lblAGILabel = new Label();
            lblBOD = new Label();
            lblBODLabel = new Label();
            lstMetatypes = new ListBox();
            lblSpecialAttributes = new Label();
            lblMetavariantKarma = new Label();
            tlpButtons = new TableLayoutPanel();
            lblMetatypeSkillSelection = new Label();
            cboSkill1 = new ElasticComboBox();
            cboSkill2 = new ElasticComboBox();
            cboSkill3 = new ElasticComboBox();
            lblSpecialAttributesLabel = new Label();
            cboTalents = new ElasticComboBox();
            tlpTopHalf = new TableLayoutPanel();
            lblHeritageLabel = new Label();
            lblAttributesLabel = new Label();
            cboResources = new ElasticComboBox();
            lblTalentLabel = new Label();
            cboSkills = new ElasticComboBox();
            lblResourcesLabel = new Label();
            cboTalent = new ElasticComboBox();
            cboAttributes = new ElasticComboBox();
            lblSkillsLabel = new Label();
            cboHeritage = new ElasticComboBox();
            lblSumtoTen = new Label();
            tlpMain = new TableLayoutPanel();
            lblMetavariantQualitiesLabel = new Label();
            pnlQualities = new Panel();
            lblMetavariantKarmaLabel = new Label();
            tlpSpirits = new TableLayoutPanel();
            chkPossessionBased = new ColorableCheckBox();
            cboPossessionMethod = new ElasticComboBox();
            lblForceLabel = new Label();
            nudForce = new NumericUpDownEx();
            tlpMetavariant = new TableLayoutPanel();
            lblMetavariantLabel = new Label();
            lblSourceLabel = new Label();
            lblSource = new Label();
            tlpButtons.SuspendLayout();
            tlpTopHalf.SuspendLayout();
            tlpMain.SuspendLayout();
            pnlQualities.SuspendLayout();
            tlpSpirits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudForce).BeginInit();
            tlpMetavariant.SuspendLayout();
            SuspendLayout();
            // 
            // cboCategory
            // 
            cboCategory.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.FormattingEnabled = true;
            cboCategory.Location = new Point(4, 175);
            cboCategory.Margin = new Padding(4, 3, 27, 3);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(353, 23);
            cboCategory.TabIndex = 6;
            cboCategory.SelectedIndexChanged += cboCategory_SelectedIndexChanged;
            // 
            // cmdCancel
            // 
            cmdCancel.AutoSize = true;
            cmdCancel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            cmdCancel.DialogResult = DialogResult.Cancel;
            cmdCancel.Dock = DockStyle.Fill;
            cmdCancel.Location = new Point(4, 3);
            cmdCancel.Margin = new Padding(4, 3, 4, 3);
            cmdCancel.MinimumSize = new Size(93, 0);
            cmdCancel.Name = "cmdCancel";
            cmdCancel.Size = new Size(93, 25);
            cmdCancel.TabIndex = 12;
            cmdCancel.Tag = "String_Cancel";
            cmdCancel.Text = "Cancel";
            cmdCancel.UseVisualStyleBackColor = true;
            cmdCancel.Click += cmdCancel_Click;
            // 
            // lblMetavariantQualities
            // 
            lblMetavariantQualities.AutoSize = true;
            lblMetavariantQualities.Dock = DockStyle.Top;
            lblMetavariantQualities.Location = new Point(4, 7);
            lblMetavariantQualities.Margin = new Padding(4, 7, 4, 7);
            lblMetavariantQualities.Name = "lblMetavariantQualities";
            lblMetavariantQualities.Size = new Size(36, 15);
            lblMetavariantQualities.TabIndex = 63;
            lblMetavariantQualities.Tag = "String_None";
            lblMetavariantQualities.Text = "None";
            // 
            // cboMetavariant
            // 
            cboMetavariant.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboMetavariant.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMetavariant.DropDownWidth = 69;
            cboMetavariant.FormattingEnabled = true;
            cboMetavariant.Location = new Point(90, 3);
            cboMetavariant.Margin = new Padding(4, 3, 4, 3);
            cboMetavariant.Name = "cboMetavariant";
            cboMetavariant.Size = new Size(417, 23);
            cboMetavariant.TabIndex = 59;
            cboMetavariant.SelectedIndexChanged += cboMetavariant_SelectedIndexChanged;
            // 
            // cmdOK
            // 
            cmdOK.AutoSize = true;
            cmdOK.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            cmdOK.Dock = DockStyle.Fill;
            cmdOK.Location = new Point(105, 3);
            cmdOK.Margin = new Padding(4, 3, 4, 3);
            cmdOK.MinimumSize = new Size(93, 0);
            cmdOK.Name = "cmdOK";
            cmdOK.Size = new Size(93, 25);
            cmdOK.TabIndex = 11;
            cmdOK.Tag = "String_OK";
            cmdOK.Text = "OK";
            cmdOK.UseVisualStyleBackColor = true;
            cmdOK.Click += cmdOK_Click;
            // 
            // lblWILLabel
            // 
            lblWILLabel.Anchor = AnchorStyles.Right;
            lblWILLabel.AutoSize = true;
            lblWILLabel.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWILLabel.Location = new Point(775, 325);
            lblWILLabel.Margin = new Padding(4, 7, 4, 7);
            lblWILLabel.Name = "lblWILLabel";
            lblWILLabel.Size = new Size(30, 13);
            lblWILLabel.TabIndex = 52;
            lblWILLabel.Tag = "String_AttributeWILShort";
            lblWILLabel.Text = "WIL";
            // 
            // lblWIL
            // 
            lblWIL.Anchor = AnchorStyles.Left;
            lblWIL.AutoSize = true;
            lblWIL.Location = new Point(813, 324);
            lblWIL.Margin = new Padding(4, 7, 4, 7);
            lblWIL.Name = "lblWIL";
            lblWIL.Size = new Size(53, 15);
            lblWIL.TabIndex = 53;
            lblWIL.Text = "2/12 (18)";
            // 
            // lblLOGLabel
            // 
            lblLOGLabel.Anchor = AnchorStyles.Right;
            lblLOGLabel.AutoSize = true;
            lblLOGLabel.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLOGLabel.Location = new Point(773, 296);
            lblLOGLabel.Margin = new Padding(4, 7, 4, 7);
            lblLOGLabel.Name = "lblLOGLabel";
            lblLOGLabel.Size = new Size(32, 13);
            lblLOGLabel.TabIndex = 50;
            lblLOGLabel.Tag = "String_AttributeLOGShort";
            lblLOGLabel.Text = "LOG";
            // 
            // lblLOG
            // 
            lblLOG.Anchor = AnchorStyles.Left;
            lblLOG.AutoSize = true;
            lblLOG.Location = new Point(813, 295);
            lblLOG.Margin = new Padding(4, 7, 4, 7);
            lblLOG.Name = "lblLOG";
            lblLOG.Size = new Size(53, 15);
            lblLOG.TabIndex = 51;
            lblLOG.Text = "2/12 (18)";
            // 
            // lblINTLabel
            // 
            lblINTLabel.Anchor = AnchorStyles.Right;
            lblINTLabel.AutoSize = true;
            lblINTLabel.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblINTLabel.Location = new Point(777, 267);
            lblINTLabel.Margin = new Padding(4, 7, 4, 7);
            lblINTLabel.Name = "lblINTLabel";
            lblINTLabel.Size = new Size(28, 13);
            lblINTLabel.TabIndex = 48;
            lblINTLabel.Tag = "String_AttributeINTShort";
            lblINTLabel.Text = "INT";
            // 
            // lblINT
            // 
            lblINT.Anchor = AnchorStyles.Left;
            lblINT.AutoSize = true;
            lblINT.Location = new Point(813, 266);
            lblINT.Margin = new Padding(4, 7, 4, 7);
            lblINT.Name = "lblINT";
            lblINT.Size = new Size(53, 15);
            lblINT.TabIndex = 49;
            lblINT.Text = "2/12 (18)";
            // 
            // lblCHALabel
            // 
            lblCHALabel.Anchor = AnchorStyles.Right;
            lblCHALabel.AutoSize = true;
            lblCHALabel.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCHALabel.Location = new Point(773, 238);
            lblCHALabel.Margin = new Padding(4, 7, 4, 7);
            lblCHALabel.Name = "lblCHALabel";
            lblCHALabel.Size = new Size(32, 13);
            lblCHALabel.TabIndex = 46;
            lblCHALabel.Tag = "String_AttributeCHAShort";
            lblCHALabel.Text = "CHA";
            // 
            // lblCHA
            // 
            lblCHA.Anchor = AnchorStyles.Left;
            lblCHA.AutoSize = true;
            lblCHA.Location = new Point(813, 237);
            lblCHA.Margin = new Padding(4, 7, 4, 7);
            lblCHA.Name = "lblCHA";
            lblCHA.Size = new Size(53, 15);
            lblCHA.TabIndex = 47;
            lblCHA.Text = "2/12 (18)";
            // 
            // lblSTR
            // 
            lblSTR.Anchor = AnchorStyles.Left;
            lblSTR.AutoSize = true;
            lblSTR.Location = new Point(643, 324);
            lblSTR.Margin = new Padding(4, 7, 4, 7);
            lblSTR.Name = "lblSTR";
            lblSTR.Size = new Size(53, 15);
            lblSTR.TabIndex = 45;
            lblSTR.Text = "2/12 (18)";
            // 
            // lblSTRLabel
            // 
            lblSTRLabel.Anchor = AnchorStyles.Right;
            lblSTRLabel.AutoSize = true;
            lblSTRLabel.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSTRLabel.Location = new Point(603, 325);
            lblSTRLabel.Margin = new Padding(4, 7, 4, 7);
            lblSTRLabel.Name = "lblSTRLabel";
            lblSTRLabel.Size = new Size(32, 13);
            lblSTRLabel.TabIndex = 44;
            lblSTRLabel.Tag = "String_AttributeSTRShort";
            lblSTRLabel.Text = "STR";
            // 
            // lblREA
            // 
            lblREA.Anchor = AnchorStyles.Left;
            lblREA.AutoSize = true;
            lblREA.Location = new Point(643, 295);
            lblREA.Margin = new Padding(4, 7, 4, 7);
            lblREA.Name = "lblREA";
            lblREA.Size = new Size(53, 15);
            lblREA.TabIndex = 43;
            lblREA.Text = "2/12 (18)";
            // 
            // lblREALabel
            // 
            lblREALabel.Anchor = AnchorStyles.Right;
            lblREALabel.AutoSize = true;
            lblREALabel.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblREALabel.Location = new Point(603, 296);
            lblREALabel.Margin = new Padding(4, 7, 4, 7);
            lblREALabel.Name = "lblREALabel";
            lblREALabel.Size = new Size(32, 13);
            lblREALabel.TabIndex = 42;
            lblREALabel.Tag = "String_AttributeREAShort";
            lblREALabel.Text = "REA";
            // 
            // lblAGI
            // 
            lblAGI.Anchor = AnchorStyles.Left;
            lblAGI.AutoSize = true;
            lblAGI.Location = new Point(643, 266);
            lblAGI.Margin = new Padding(4, 7, 4, 7);
            lblAGI.Name = "lblAGI";
            lblAGI.Size = new Size(53, 15);
            lblAGI.TabIndex = 41;
            lblAGI.Text = "2/12 (18)";
            // 
            // lblAGILabel
            // 
            lblAGILabel.Anchor = AnchorStyles.Right;
            lblAGILabel.AutoSize = true;
            lblAGILabel.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAGILabel.Location = new Point(607, 267);
            lblAGILabel.Margin = new Padding(4, 7, 4, 7);
            lblAGILabel.Name = "lblAGILabel";
            lblAGILabel.Size = new Size(28, 13);
            lblAGILabel.TabIndex = 40;
            lblAGILabel.Tag = "String_AttributeAGIShort";
            lblAGILabel.Text = "AGI";
            // 
            // lblBOD
            // 
            lblBOD.Anchor = AnchorStyles.Left;
            lblBOD.AutoSize = true;
            lblBOD.Location = new Point(643, 237);
            lblBOD.Margin = new Padding(4, 7, 4, 7);
            lblBOD.Name = "lblBOD";
            lblBOD.Size = new Size(53, 15);
            lblBOD.TabIndex = 39;
            lblBOD.Text = "2/12 (18)";
            // 
            // lblBODLabel
            // 
            lblBODLabel.Anchor = AnchorStyles.Right;
            lblBODLabel.AutoSize = true;
            lblBODLabel.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBODLabel.Location = new Point(602, 238);
            lblBODLabel.Margin = new Padding(4, 7, 4, 7);
            lblBODLabel.Name = "lblBODLabel";
            lblBODLabel.Size = new Size(33, 13);
            lblBODLabel.TabIndex = 38;
            lblBODLabel.Tag = "String_AttributeBODShort";
            lblBODLabel.Text = "BOD";
            // 
            // lstMetatypes
            // 
            lstMetatypes.Dock = DockStyle.Fill;
            lstMetatypes.FormattingEnabled = true;
            lstMetatypes.Location = new Point(4, 204);
            lstMetatypes.Margin = new Padding(4, 3, 27, 3);
            lstMetatypes.Name = "lstMetatypes";
            tlpMain.SetRowSpan(lstMetatypes, 11);
            lstMetatypes.Size = new Size(353, 420);
            lstMetatypes.Sorted = true;
            lstMetatypes.TabIndex = 7;
            lstMetatypes.SelectedIndexChanged += lstMetatypes_SelectedIndexChanged;
            lstMetatypes.DoubleClick += cmdOK_Click;
            // 
            // lblSpecialAttributes
            // 
            lblSpecialAttributes.Anchor = AnchorStyles.Left;
            lblSpecialAttributes.AutoSize = true;
            lblSpecialAttributes.Location = new Point(473, 280);
            lblSpecialAttributes.Margin = new Padding(4, 7, 4, 7);
            lblSpecialAttributes.Name = "lblSpecialAttributes";
            tlpMain.SetRowSpan(lblSpecialAttributes, 2);
            lblSpecialAttributes.Size = new Size(13, 15);
            lblSpecialAttributes.TabIndex = 71;
            lblSpecialAttributes.Text = "0";
            lblSpecialAttributes.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblMetavariantKarma
            // 
            lblMetavariantKarma.Anchor = AnchorStyles.Left;
            lblMetavariantKarma.AutoSize = true;
            lblMetavariantKarma.Location = new Point(473, 237);
            lblMetavariantKarma.Margin = new Padding(4, 7, 4, 7);
            lblMetavariantKarma.Name = "lblMetavariantKarma";
            lblMetavariantKarma.Size = new Size(13, 15);
            lblMetavariantKarma.TabIndex = 77;
            lblMetavariantKarma.Text = "0";
            lblMetavariantKarma.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tlpButtons
            // 
            tlpButtons.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            tlpButtons.AutoSize = true;
            tlpButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpButtons.ColumnCount = 2;
            tlpMain.SetColumnSpan(tlpButtons, 6);
            tlpButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpButtons.Controls.Add(cmdCancel, 0, 0);
            tlpButtons.Controls.Add(cmdOK, 1, 0);
            tlpButtons.Location = new Point(693, 596);
            tlpButtons.Margin = new Padding(0);
            tlpButtons.Name = "tlpButtons";
            tlpButtons.RowCount = 1;
            tlpButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpButtons.Size = new Size(202, 31);
            tlpButtons.TabIndex = 80;
            // 
            // lblMetatypeSkillSelection
            // 
            lblMetatypeSkillSelection.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblMetatypeSkillSelection.AutoSize = true;
            tlpMain.SetColumnSpan(lblMetatypeSkillSelection, 6);
            lblMetatypeSkillSelection.Location = new Point(388, 487);
            lblMetatypeSkillSelection.Margin = new Padding(4, 7, 4, 7);
            lblMetatypeSkillSelection.Name = "lblMetatypeSkillSelection";
            lblMetatypeSkillSelection.Size = new Size(439, 15);
            lblMetatypeSkillSelection.TabIndex = 75;
            lblMetatypeSkillSelection.Tag = "String_MetamagicSkillBase";
            lblMetatypeSkillSelection.Text = "Based on your talent selection, you may choose 2 magical skills to start at rating 5.";
            lblMetatypeSkillSelection.Visible = false;
            // 
            // cboSkill1
            // 
            cboSkill1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tlpMain.SetColumnSpan(cboSkill1, 6);
            cboSkill1.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSkill1.FormattingEnabled = true;
            cboSkill1.Location = new Point(388, 512);
            cboSkill1.Margin = new Padding(4, 3, 4, 3);
            cboSkill1.Name = "cboSkill1";
            cboSkill1.Size = new Size(503, 23);
            cboSkill1.TabIndex = 9;
            cboSkill1.Visible = false;
            // 
            // cboSkill2
            // 
            cboSkill2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tlpMain.SetColumnSpan(cboSkill2, 6);
            cboSkill2.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSkill2.FormattingEnabled = true;
            cboSkill2.Location = new Point(388, 541);
            cboSkill2.Margin = new Padding(4, 3, 4, 3);
            cboSkill2.Name = "cboSkill2";
            cboSkill2.Size = new Size(503, 23);
            cboSkill2.TabIndex = 10;
            cboSkill2.Visible = false;
            // 
            // cboSkill3
            // 
            cboSkill3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tlpMain.SetColumnSpan(cboSkill3, 6);
            cboSkill3.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSkill3.FormattingEnabled = true;
            cboSkill3.Location = new Point(388, 570);
            cboSkill3.Margin = new Padding(4, 3, 4, 3);
            cboSkill3.Name = "cboSkill3";
            cboSkill3.Size = new Size(503, 23);
            cboSkill3.TabIndex = 78;
            cboSkill3.Visible = false;
            // 
            // lblSpecialAttributesLabel
            // 
            lblSpecialAttributesLabel.Anchor = AnchorStyles.Right;
            lblSpecialAttributesLabel.AutoSize = true;
            lblSpecialAttributesLabel.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSpecialAttributesLabel.Location = new Point(400, 275);
            lblSpecialAttributesLabel.Margin = new Padding(4, 7, 4, 7);
            lblSpecialAttributesLabel.Name = "lblSpecialAttributesLabel";
            tlpMain.SetRowSpan(lblSpecialAttributesLabel, 2);
            lblSpecialAttributesLabel.Size = new Size(65, 26);
            lblSpecialAttributesLabel.TabIndex = 70;
            lblSpecialAttributesLabel.Tag = "Label_SpecialAttributes";
            lblSpecialAttributesLabel.Text = "Special Attributes:";
            lblSpecialAttributesLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cboTalents
            // 
            cboTalents.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboTalents.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTalents.FormattingEnabled = true;
            cboTalents.Location = new Point(514, 61);
            cboTalents.Margin = new Padding(4, 3, 4, 3);
            cboTalents.Name = "cboTalents";
            cboTalents.Size = new Size(377, 23);
            cboTalents.TabIndex = 8;
            cboTalents.SelectedIndexChanged += cboTalents_SelectedIndexChanged;
            // 
            // tlpTopHalf
            // 
            tlpTopHalf.AutoSize = true;
            tlpTopHalf.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpTopHalf.ColumnCount = 3;
            tlpMain.SetColumnSpan(tlpTopHalf, 7);
            tlpTopHalf.ColumnStyles.Add(new ColumnStyle());
            tlpTopHalf.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpTopHalf.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpTopHalf.Controls.Add(cboTalents, 2, 2);
            tlpTopHalf.Controls.Add(lblHeritageLabel, 0, 0);
            tlpTopHalf.Controls.Add(lblAttributesLabel, 0, 1);
            tlpTopHalf.Controls.Add(cboResources, 1, 4);
            tlpTopHalf.Controls.Add(lblTalentLabel, 0, 2);
            tlpTopHalf.Controls.Add(cboSkills, 1, 3);
            tlpTopHalf.Controls.Add(lblResourcesLabel, 0, 4);
            tlpTopHalf.Controls.Add(cboTalent, 1, 2);
            tlpTopHalf.Controls.Add(cboAttributes, 1, 1);
            tlpTopHalf.Controls.Add(lblSkillsLabel, 0, 3);
            tlpTopHalf.Controls.Add(cboHeritage, 1, 0);
            tlpTopHalf.Controls.Add(lblSumtoTen, 2, 3);
            tlpTopHalf.Dock = DockStyle.Fill;
            tlpTopHalf.Location = new Point(0, 0);
            tlpTopHalf.Margin = new Padding(0, 0, 0, 27);
            tlpTopHalf.Name = "tlpTopHalf";
            tlpTopHalf.RowCount = 5;
            tlpTopHalf.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpTopHalf.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpTopHalf.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpTopHalf.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpTopHalf.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpTopHalf.Size = new Size(895, 145);
            tlpTopHalf.TabIndex = 105;
            // 
            // lblHeritageLabel
            // 
            lblHeritageLabel.Anchor = AnchorStyles.Right;
            lblHeritageLabel.AutoSize = true;
            lblHeritageLabel.Location = new Point(61, 7);
            lblHeritageLabel.Margin = new Padding(4, 7, 4, 7);
            lblHeritageLabel.Name = "lblHeritageLabel";
            lblHeritageLabel.Size = new Size(60, 15);
            lblHeritageLabel.TabIndex = 102;
            lblHeritageLabel.Tag = "Label_PriorityHeritage";
            lblHeritageLabel.Text = "Metatype:";
            // 
            // lblAttributesLabel
            // 
            lblAttributesLabel.Anchor = AnchorStyles.Right;
            lblAttributesLabel.AutoSize = true;
            lblAttributesLabel.Location = new Point(59, 36);
            lblAttributesLabel.Margin = new Padding(4, 7, 4, 7);
            lblAttributesLabel.Name = "lblAttributesLabel";
            lblAttributesLabel.Size = new Size(62, 15);
            lblAttributesLabel.TabIndex = 106;
            lblAttributesLabel.Tag = "Label_PriorityAttributes";
            lblAttributesLabel.Text = "Attributes:";
            // 
            // cboResources
            // 
            cboResources.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboResources.DropDownStyle = ComboBoxStyle.DropDownList;
            cboResources.FormattingEnabled = true;
            cboResources.Location = new Point(129, 119);
            cboResources.Margin = new Padding(4, 3, 4, 3);
            cboResources.Name = "cboResources";
            cboResources.Size = new Size(377, 23);
            cboResources.TabIndex = 5;
            cboResources.SelectedIndexChanged += cboResources_SelectedIndexChanged;
            // 
            // lblTalentLabel
            // 
            lblTalentLabel.Anchor = AnchorStyles.Right;
            lblTalentLabel.AutoSize = true;
            lblTalentLabel.Location = new Point(4, 65);
            lblTalentLabel.Margin = new Padding(4, 7, 4, 7);
            lblTalentLabel.Name = "lblTalentLabel";
            lblTalentLabel.Size = new Size(117, 15);
            lblTalentLabel.TabIndex = 104;
            lblTalentLabel.Tag = "Label_PriorityTalent";
            lblTalentLabel.Text = "Magic or Resonance:";
            // 
            // cboSkills
            // 
            cboSkills.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboSkills.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSkills.FormattingEnabled = true;
            cboSkills.Location = new Point(129, 90);
            cboSkills.Margin = new Padding(4, 3, 4, 3);
            cboSkills.Name = "cboSkills";
            cboSkills.Size = new Size(377, 23);
            cboSkills.TabIndex = 4;
            cboSkills.SelectedIndexChanged += cboSkills_SelectedIndexChanged;
            // 
            // lblResourcesLabel
            // 
            lblResourcesLabel.Anchor = AnchorStyles.Right;
            lblResourcesLabel.AutoSize = true;
            lblResourcesLabel.Location = new Point(58, 123);
            lblResourcesLabel.Margin = new Padding(4, 7, 4, 7);
            lblResourcesLabel.Name = "lblResourcesLabel";
            lblResourcesLabel.Size = new Size(63, 15);
            lblResourcesLabel.TabIndex = 110;
            lblResourcesLabel.Tag = "Label_PriorityResources";
            lblResourcesLabel.Text = "Resources:";
            // 
            // cboTalent
            // 
            cboTalent.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboTalent.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTalent.FormattingEnabled = true;
            cboTalent.Location = new Point(129, 61);
            cboTalent.Margin = new Padding(4, 3, 4, 3);
            cboTalent.Name = "cboTalent";
            cboTalent.Size = new Size(377, 23);
            cboTalent.TabIndex = 3;
            cboTalent.SelectedIndexChanged += cboTalent_SelectedIndexChanged;
            // 
            // cboAttributes
            // 
            cboAttributes.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboAttributes.DropDownStyle = ComboBoxStyle.DropDownList;
            cboAttributes.FormattingEnabled = true;
            cboAttributes.Location = new Point(129, 32);
            cboAttributes.Margin = new Padding(4, 3, 4, 3);
            cboAttributes.Name = "cboAttributes";
            cboAttributes.Size = new Size(377, 23);
            cboAttributes.TabIndex = 2;
            cboAttributes.SelectedIndexChanged += cboAttributes_SelectedIndexChanged;
            // 
            // lblSkillsLabel
            // 
            lblSkillsLabel.Anchor = AnchorStyles.Right;
            lblSkillsLabel.AutoSize = true;
            lblSkillsLabel.Location = new Point(85, 94);
            lblSkillsLabel.Margin = new Padding(4, 7, 4, 7);
            lblSkillsLabel.Name = "lblSkillsLabel";
            lblSkillsLabel.Size = new Size(36, 15);
            lblSkillsLabel.TabIndex = 108;
            lblSkillsLabel.Tag = "Label_PrioritySkills";
            lblSkillsLabel.Text = "Skills:";
            // 
            // cboHeritage
            // 
            cboHeritage.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboHeritage.DropDownStyle = ComboBoxStyle.DropDownList;
            cboHeritage.FormattingEnabled = true;
            cboHeritage.Location = new Point(129, 3);
            cboHeritage.Margin = new Padding(4, 3, 4, 3);
            cboHeritage.Name = "cboHeritage";
            cboHeritage.Size = new Size(377, 23);
            cboHeritage.TabIndex = 1;
            cboHeritage.SelectedIndexChanged += cboHeritage_SelectedIndexChanged;
            // 
            // lblSumtoTen
            // 
            lblSumtoTen.Anchor = AnchorStyles.None;
            lblSumtoTen.AutoSize = true;
            lblSumtoTen.Font = new Font("Microsoft Sans Serif", 16.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSumtoTen.Location = new Point(675, 103);
            lblSumtoTen.Margin = new Padding(4, 7, 4, 7);
            lblSumtoTen.Name = "lblSumtoTen";
            tlpTopHalf.SetRowSpan(lblSumtoTen, 2);
            lblSumtoTen.Size = new Size(54, 26);
            lblSumtoTen.TabIndex = 111;
            lblSumtoTen.Text = "0/10";
            lblSumtoTen.TextAlign = ContentAlignment.MiddleCenter;
            lblSumtoTen.Visible = false;
            // 
            // tlpMain
            // 
            tlpMain.ColumnCount = 7;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 43F));
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9.5F));
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9.5F));
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9.5F));
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9.5F));
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9.5F));
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9.5F));
            tlpMain.Controls.Add(lstMetatypes, 0, 3);
            tlpMain.Controls.Add(cboCategory, 0, 2);
            tlpMain.Controls.Add(lblMetavariantQualitiesLabel, 1, 8);
            tlpMain.Controls.Add(cboSkill1, 1, 10);
            tlpMain.Controls.Add(cboSkill2, 1, 11);
            tlpMain.Controls.Add(tlpTopHalf, 0, 0);
            tlpMain.Controls.Add(tlpButtons, 1, 13);
            tlpMain.Controls.Add(cboSkill3, 1, 12);
            tlpMain.Controls.Add(pnlQualities, 2, 8);
            tlpMain.Controls.Add(lblWILLabel, 5, 7);
            tlpMain.Controls.Add(lblWIL, 6, 7);
            tlpMain.Controls.Add(lblSTRLabel, 3, 7);
            tlpMain.Controls.Add(lblSTR, 4, 7);
            tlpMain.Controls.Add(lblREALabel, 3, 6);
            tlpMain.Controls.Add(lblREA, 4, 6);
            tlpMain.Controls.Add(lblAGILabel, 3, 5);
            tlpMain.Controls.Add(lblAGI, 4, 5);
            tlpMain.Controls.Add(lblBODLabel, 3, 4);
            tlpMain.Controls.Add(lblBOD, 4, 4);
            tlpMain.Controls.Add(lblLOGLabel, 5, 6);
            tlpMain.Controls.Add(lblLOG, 6, 6);
            tlpMain.Controls.Add(lblINT, 6, 5);
            tlpMain.Controls.Add(lblCHA, 6, 4);
            tlpMain.Controls.Add(lblINTLabel, 5, 5);
            tlpMain.Controls.Add(lblCHALabel, 5, 4);
            tlpMain.Controls.Add(lblMetavariantKarmaLabel, 1, 4);
            tlpMain.Controls.Add(lblMetavariantKarma, 2, 4);
            tlpMain.Controls.Add(tlpSpirits, 1, 3);
            tlpMain.Controls.Add(tlpMetavariant, 1, 2);
            tlpMain.Controls.Add(lblSpecialAttributesLabel, 1, 5);
            tlpMain.Controls.Add(lblSpecialAttributes, 2, 5);
            tlpMain.Controls.Add(lblSourceLabel, 1, 7);
            tlpMain.Controls.Add(lblSource, 2, 7);
            tlpMain.Controls.Add(lblMetatypeSkillSelection, 1, 9);
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Location = new Point(10, 10);
            tlpMain.Margin = new Padding(0);
            tlpMain.Name = "tlpMain";
            tlpMain.RowCount = 14;
            tlpMain.RowStyles.Add(new RowStyle());
            tlpMain.RowStyles.Add(new RowStyle());
            tlpMain.RowStyles.Add(new RowStyle());
            tlpMain.RowStyles.Add(new RowStyle());
            tlpMain.RowStyles.Add(new RowStyle());
            tlpMain.RowStyles.Add(new RowStyle());
            tlpMain.RowStyles.Add(new RowStyle());
            tlpMain.RowStyles.Add(new RowStyle());
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMain.RowStyles.Add(new RowStyle());
            tlpMain.RowStyles.Add(new RowStyle());
            tlpMain.RowStyles.Add(new RowStyle());
            tlpMain.RowStyles.Add(new RowStyle());
            tlpMain.RowStyles.Add(new RowStyle());
            tlpMain.Size = new Size(895, 627);
            tlpMain.TabIndex = 106;
            // 
            // lblMetavariantQualitiesLabel
            // 
            lblMetavariantQualitiesLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblMetavariantQualitiesLabel.AutoSize = true;
            lblMetavariantQualitiesLabel.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMetavariantQualitiesLabel.Location = new Point(405, 353);
            lblMetavariantQualitiesLabel.Margin = new Padding(4, 7, 4, 7);
            lblMetavariantQualitiesLabel.Name = "lblMetavariantQualitiesLabel";
            lblMetavariantQualitiesLabel.Size = new Size(60, 13);
            lblMetavariantQualitiesLabel.TabIndex = 62;
            lblMetavariantQualitiesLabel.Tag = "Label_Qualities";
            lblMetavariantQualitiesLabel.Text = "Qualities:";
            // 
            // pnlQualities
            // 
            pnlQualities.AutoScroll = true;
            tlpMain.SetColumnSpan(pnlQualities, 5);
            pnlQualities.Controls.Add(lblMetavariantQualities);
            pnlQualities.Dock = DockStyle.Fill;
            pnlQualities.Location = new Point(469, 346);
            pnlQualities.Margin = new Padding(0);
            pnlQualities.Name = "pnlQualities";
            pnlQualities.Padding = new Padding(4, 7, 15, 7);
            pnlQualities.Size = new Size(426, 134);
            pnlQualities.TabIndex = 106;
            // 
            // lblMetavariantKarmaLabel
            // 
            lblMetavariantKarmaLabel.Anchor = AnchorStyles.Right;
            lblMetavariantKarmaLabel.AutoSize = true;
            lblMetavariantKarmaLabel.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMetavariantKarmaLabel.Location = new Point(419, 238);
            lblMetavariantKarmaLabel.Margin = new Padding(4, 7, 4, 7);
            lblMetavariantKarmaLabel.Name = "lblMetavariantKarmaLabel";
            lblMetavariantKarmaLabel.Size = new Size(46, 13);
            lblMetavariantKarmaLabel.TabIndex = 76;
            lblMetavariantKarmaLabel.Tag = "Label_Karma";
            lblMetavariantKarmaLabel.Text = "Karma:";
            lblMetavariantKarmaLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tlpSpirits
            // 
            tlpSpirits.AutoSize = true;
            tlpSpirits.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpSpirits.ColumnCount = 4;
            tlpMain.SetColumnSpan(tlpSpirits, 6);
            tlpSpirits.ColumnStyles.Add(new ColumnStyle());
            tlpSpirits.ColumnStyles.Add(new ColumnStyle());
            tlpSpirits.ColumnStyles.Add(new ColumnStyle());
            tlpSpirits.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpSpirits.Controls.Add(cboPossessionMethod, 3, 0);
            tlpSpirits.Controls.Add(lblForceLabel, 0, 0);
            tlpSpirits.Controls.Add(nudForce, 1, 0);
            tlpSpirits.Dock = DockStyle.Fill;
            tlpSpirits.Location = new Point(384, 201);
            tlpSpirits.Margin = new Padding(0);
            tlpSpirits.Name = "tlpSpirits";
            tlpSpirits.RowCount = 1;
            tlpSpirits.RowStyles.Add(new RowStyle());
            tlpSpirits.Size = new Size(511, 29);
            tlpSpirits.TabIndex = 107;
            // 
            // chkPossessionBased
            // 
            chkPossessionBased.Anchor = AnchorStyles.Left;
            chkPossessionBased.AutoSize = true;
            chkPossessionBased.DefaultColorScheme = true;
            chkPossessionBased.Location = new Point(98, 5);
            chkPossessionBased.Name = "chkPossessionBased";
            chkPossessionBased.Size = new Size(211, 17);
            chkPossessionBased.TabIndex = 64;
            chkPossessionBased.Tag = "Checkbox_Metatype_PossessionTradition";
            chkPossessionBased.Text = "Summoned by Possess-based Tradition";
            chkPossessionBased.TextAlign =ContentAlignment.TopLeft;
            chkPossessionBased.UseVisualStyleBackColor = true;
            chkPossessionBased.Visible = false;
            chkPossessionBased.CheckedChanged += new System.EventHandler(this.chkPossessionBased_CheckedChanged);
            // 
            // cboPossessionMethod
            // 
            cboPossessionMethod.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboPossessionMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPossessionMethod.Enabled = false;
            cboPossessionMethod.FormattingEnabled = true;
            cboPossessionMethod.Location = new Point(107, 3);
            cboPossessionMethod.Margin = new Padding(4, 3, 4, 3);
            cboPossessionMethod.Name = "cboPossessionMethod";
            cboPossessionMethod.Size = new Size(400, 23);
            cboPossessionMethod.TabIndex = 65;
            cboPossessionMethod.Visible = false;
            // 
            // lblForceLabel
            // 
            lblForceLabel.Anchor = AnchorStyles.Right;
            lblForceLabel.AutoSize = true;
            lblForceLabel.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblForceLabel.Location = new Point(4, 8);
            lblForceLabel.Margin = new Padding(4, 7, 4, 7);
            lblForceLabel.Name = "lblForceLabel";
            lblForceLabel.Size = new Size(48, 13);
            lblForceLabel.TabIndex = 56;
            lblForceLabel.Tag = "String_Force";
            lblForceLabel.Text = "FORCE";
            lblForceLabel.Visible = false;
            // 
            // nudForce
            // 
            nudForce.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            nudForce.AutoSize = true;
            nudForce.Location = new Point(59, 3);
            nudForce.Name = "nudForce";
            nudForce.Size = new Size(41, 23);
            nudForce.TabIndex = 57;
            nudForce.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nudForce.Visible = false;
            // 
            // tlpMetavariant
            // 
            tlpMetavariant.AutoSize = true;
            tlpMetavariant.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpMetavariant.ColumnCount = 2;
            tlpMain.SetColumnSpan(tlpMetavariant, 6);
            tlpMetavariant.ColumnStyles.Add(new ColumnStyle());
            tlpMetavariant.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpMetavariant.Controls.Add(lblMetavariantLabel, 0, 0);
            tlpMetavariant.Controls.Add(cboMetavariant, 1, 0);
            tlpMetavariant.Dock = DockStyle.Fill;
            tlpMetavariant.Location = new Point(384, 172);
            tlpMetavariant.Margin = new Padding(0);
            tlpMetavariant.Name = "tlpMetavariant";
            tlpMetavariant.RowCount = 1;
            tlpMetavariant.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMetavariant.Size = new Size(511, 29);
            tlpMetavariant.TabIndex = 108;
            // 
            // lblMetavariantLabel
            // 
            lblMetavariantLabel.Anchor = AnchorStyles.Right;
            lblMetavariantLabel.AutoSize = true;
            lblMetavariantLabel.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMetavariantLabel.Location = new Point(4, 8);
            lblMetavariantLabel.Margin = new Padding(4, 7, 4, 7);
            lblMetavariantLabel.Name = "lblMetavariantLabel";
            lblMetavariantLabel.Size = new Size(78, 13);
            lblMetavariantLabel.TabIndex = 58;
            lblMetavariantLabel.Tag = "Label_Metavariant";
            lblMetavariantLabel.Text = "Metavariant:";
            lblMetavariantLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblSourceLabel
            // 
            lblSourceLabel.Anchor = AnchorStyles.Right;
            lblSourceLabel.AutoSize = true;
            lblSourceLabel.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSourceLabel.Location = new Point(414, 325);
            lblSourceLabel.Margin = new Padding(4, 7, 4, 7);
            lblSourceLabel.Name = "lblSourceLabel";
            lblSourceLabel.Size = new Size(51, 13);
            lblSourceLabel.TabIndex = 109;
            lblSourceLabel.Tag = "Label_Source";
            lblSourceLabel.Text = "Source:";
            lblSourceLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblSource
            // 
            lblSource.Anchor = AnchorStyles.Left;
            lblSource.AutoSize = true;
            lblSource.Cursor = Cursors.Hand;
            lblSource.Location = new Point(473, 324);
            lblSource.Margin = new Padding(4, 7, 4, 7);
            lblSource.Name = "lblSource";
            lblSource.Size = new Size(51, 15);
            lblSource.TabIndex = 110;
            lblSource.Text = "[Source]";
            lblSource.TextAlign = ContentAlignment.MiddleLeft;
            lblSource.Click += OpenSourceFromLabel;
            // 
            // SelectMetatypePriority
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(915, 647);
            Controls.Add(tlpMain);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SelectMetatypePriority";
            Padding = new Padding(10);
            StartPosition = FormStartPosition.CenterParent;
            Tag = "Title_ChooseCharacterPriorities";
            Text = "Choose Character Priorities";
            FormClosing += SelectMetatypePriority_Closing;
            Load += SelectMetatypePriority_Load;
            tlpButtons.ResumeLayout(false);
            tlpButtons.PerformLayout();
            tlpTopHalf.ResumeLayout(false);
            tlpTopHalf.PerformLayout();
            tlpMain.ResumeLayout(false);
            tlpMain.PerformLayout();
            pnlQualities.ResumeLayout(false);
            pnlQualities.PerformLayout();
            tlpSpirits.ResumeLayout(false);
            tlpSpirits.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudForce).EndInit();
            tlpMetavariant.ResumeLayout(false);
            tlpMetavariant.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label lblMetavariantKarma;
        private ElasticComboBox cboCategory;
        internal System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Label lblMetavariantQualities;
        private ElasticComboBox cboMetavariant;
        internal System.Windows.Forms.Button cmdOK;
        internal System.Windows.Forms.Label lblWILLabel;
        internal System.Windows.Forms.Label lblWIL;
        internal System.Windows.Forms.Label lblLOGLabel;
        internal System.Windows.Forms.Label lblLOG;
        internal System.Windows.Forms.Label lblINTLabel;
        internal System.Windows.Forms.Label lblINT;
        internal System.Windows.Forms.Label lblCHALabel;
        internal System.Windows.Forms.Label lblCHA;
        internal System.Windows.Forms.Label lblSTR;
        internal System.Windows.Forms.Label lblSTRLabel;
        internal System.Windows.Forms.Label lblREA;
        internal System.Windows.Forms.Label lblREALabel;
        internal System.Windows.Forms.Label lblAGI;
        internal System.Windows.Forms.Label lblAGILabel;
        internal System.Windows.Forms.Label lblBOD;
        internal System.Windows.Forms.Label lblBODLabel;
        internal System.Windows.Forms.ListBox lstMetatypes;
        internal System.Windows.Forms.Label lblSpecialAttributes;
        internal System.Windows.Forms.Label lblSpecialAttributesLabel;
        private ElasticComboBox cboTalents;
        private System.Windows.Forms.Label lblMetatypeSkillSelection;
        private ElasticComboBox cboSkill1;
        private ElasticComboBox cboSkill2;
        private ElasticComboBox cboSkill3;
        private System.Windows.Forms.TableLayoutPanel tlpTopHalf;
        private System.Windows.Forms.Label lblHeritageLabel;
        private System.Windows.Forms.Label lblAttributesLabel;
        private ElasticComboBox cboResources;
        private System.Windows.Forms.Label lblTalentLabel;
        private ElasticComboBox cboSkills;
        private System.Windows.Forms.Label lblResourcesLabel;
        private ElasticComboBox cboTalent;
        private ElasticComboBox cboAttributes;
        private System.Windows.Forms.Label lblSkillsLabel;
        private ElasticComboBox cboHeritage;
        private System.Windows.Forms.Label lblSumtoTen;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tlpButtons;
        internal System.Windows.Forms.Label lblMetavariantKarmaLabel;
        private System.Windows.Forms.Label lblMetavariantLabel;
        private System.Windows.Forms.Label lblMetavariantQualitiesLabel;
        private System.Windows.Forms.Panel pnlQualities;
        private System.Windows.Forms.TableLayoutPanel tlpSpirits;
        private ColorableCheckBox chkPossessionBased;
        private ElasticComboBox cboPossessionMethod;
        private System.Windows.Forms.Label lblForceLabel;
        private NumericUpDownEx nudForce;
        private System.Windows.Forms.TableLayoutPanel tlpMetavariant;
        internal System.Windows.Forms.Label lblSourceLabel;
        internal System.Windows.Forms.Label lblSource;
    }
}
