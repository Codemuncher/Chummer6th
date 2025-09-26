using System.Threading;

namespace Chummer
{
    partial class SelectWeapon
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
            if (disposing)
            {
                CancellationTokenSource objOldCancellationTokenSource = Interlocked.Exchange(ref _objUpdateWeaponInfoCancellationTokenSource, null);
                if (objOldCancellationTokenSource?.IsCancellationRequested == false)
                {
                    objOldCancellationTokenSource.Cancel(false);
                    objOldCancellationTokenSource.Dispose();
                }
                objOldCancellationTokenSource = Interlocked.Exchange(ref _objDoRefreshListCancellationTokenSource, null);
                if (objOldCancellationTokenSource?.IsCancellationRequested == false)
                {
                    objOldCancellationTokenSource.Cancel(false);
                    objOldCancellationTokenSource.Dispose();
                }
                objOldCancellationTokenSource = Interlocked.Exchange(ref _objWeaponSelectedIndexChangedCancellationTokenSource, null);
                if (objOldCancellationTokenSource?.IsCancellationRequested == false)
                {
                    objOldCancellationTokenSource.Cancel(false);
                    objOldCancellationTokenSource.Dispose();
                }
                _objGenericCancellationTokenSource.Dispose();
                Utils.ListItemListPool.Return(ref _lstCategory);
                Utils.StringHashSetPool.Return(ref _setBlackMarketMaps);
                Utils.StringHashSetPool.Return(ref _setLimitToCategories);
                Utils.StringHashSetPool.Return(ref _setMounts);
                if (components != null)
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            cmdOK = new Button();
            cmdCancel = new Button();
            tlpMain = new TableLayoutPanel();
            tabControl = new TabControl();
            tabListView = new TabPage();
            tlpWeapon = new TableLayoutPanel();
            lstWeapon = new ListBox();
            tlpRight = new TableLayoutPanel();
            lblWeaponConceal = new Label();
            lblSourceLabel = new Label();
            lblWeaponDamageLabel = new Label();
            lblWeaponConcealLabel = new Label();
            lblWeaponDamage = new Label();
            lblWeaponRCLabel = new Label();
            flpMarkup = new FlowLayoutPanel();
            nudMarkup = new NumericUpDownEx();
            lblMarkupPercentLabel = new Label();
            lblMarkupLabel = new Label();
            flpCheckBoxes = new FlowLayoutPanel();
            lblWeaponMode = new Label();
            lblWeaponCost = new Label();
            lblWeaponCostLabel = new Label();
            lblWeaponAmmo = new Label();
            lblWeaponModeLabel = new Label();
            lblWeaponReach = new Label();
            lblTest = new Label();
            lblTestLabel = new Label();
            lblWeaponAvail = new Label();
            lblWeaponAvailLabel = new Label();
            lblWeaponReachLabel = new Label();
            lblWeaponAmmoLabel = new Label();
            lblWeaponAPLabel = new Label();
            lblWeaponAccuracyLabel = new Label();
            lblWeaponAccuracy = new Label();
            lblWeaponAP = new Label();
            tlpBottomRight = new TableLayoutPanel();
            gpbIncludedAccessories = new GroupBox();
            pnlIncludedAccessories = new Panel();
            lblIncludedAccessories = new Label();
            tabBrowse = new TabPage();
            dgvWeapons = new DataGridView();
            dgvc_Guid = new DataGridViewTextBoxColumn();
            dgvc_Name = new DataGridViewTextBoxColumnTranslated();
            dgvc_Dice = new DataGridViewTextBoxColumnTranslated();
            dgvc_Accuracy = new DataGridViewTextBoxColumnTranslated();
            dgvc_Damage = new DataGridViewTextBoxColumnTranslated();
            dgvc_AP = new DataGridViewTextBoxColumnTranslated();
            dgvc_RC = new DataGridViewTextBoxColumnTranslated();
            dgvc_Ammo = new DataGridViewTextBoxColumnTranslated();
            dgvc_Mode = new DataGridViewTextBoxColumnTranslated();
            dgvc_Reach = new DataGridViewTextBoxColumnTranslated();
            dgvc_Conceal = new DataGridViewTextBoxColumnTranslated();
            dgvc_Accessories = new DataGridViewTextBoxColumnTranslated();
            Label_Avail = new DataGridViewTextBoxColumnTranslated();
            Label_Source = new DataGridViewTextBoxColumnTranslated();
            dgvc_Cost = new DataGridViewTextBoxColumnTranslated();
            lblCategory = new Label();
            cboCategory = new ElasticComboBox();
            txtSearch = new TextBox();
            lblSearchLabel = new Label();
            tlpButtons = new TableLayoutPanel();
            cmdOKAdd = new Button();
            tlpMain.SuspendLayout();
            tabControl.SuspendLayout();
            tabListView.SuspendLayout();
            tlpWeapon.SuspendLayout();
            tlpRight.SuspendLayout();
            flpMarkup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudMarkup).BeginInit();
            tlpBottomRight.SuspendLayout();
            gpbIncludedAccessories.SuspendLayout();
            pnlIncludedAccessories.SuspendLayout();
            tabBrowse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvWeapons).BeginInit();
            tlpButtons.SuspendLayout();
            SuspendLayout();
            // 
            // cmdOK
            // 
            cmdOK.AutoSize = true;
            cmdOK.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            cmdOK.Dock = DockStyle.Fill;
            cmdOK.Location = new Point(204, 3);
            cmdOK.Margin = new Padding(4, 3, 4, 3);
            cmdOK.MinimumSize = new Size(93, 0);
            cmdOK.Name = "cmdOK";
            cmdOK.Size = new Size(95, 25);
            cmdOK.TabIndex = 31;
            cmdOK.Tag = "String_OK";
            cmdOK.Text = "OK";
            cmdOK.UseVisualStyleBackColor = true;
            cmdOK.Click += cmdOK_Click;
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
            cmdCancel.TabIndex = 33;
            cmdCancel.Tag = "String_Cancel";
            cmdCancel.Text = "Cancel";
            cmdCancel.UseVisualStyleBackColor = true;
            cmdCancel.Click += cmdCancel_Click;
            // 
            // tlpMain
            // 
            tlpMain.AutoSize = true;
            tlpMain.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpMain.ColumnCount = 4;
            tlpMain.ColumnStyles.Add(new ColumnStyle());
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpMain.ColumnStyles.Add(new ColumnStyle());
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpMain.Controls.Add(tabControl, 0, 1);
            tlpMain.Controls.Add(lblCategory, 0, 0);
            tlpMain.Controls.Add(cboCategory, 1, 0);
            tlpMain.Controls.Add(txtSearch, 3, 0);
            tlpMain.Controls.Add(lblSearchLabel, 2, 0);
            tlpMain.Controls.Add(tlpButtons, 0, 2);
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Location = new Point(10, 10);
            tlpMain.Margin = new Padding(4, 3, 4, 3);
            tlpMain.Name = "tlpMain";
            tlpMain.RowCount = 3;
            tlpMain.RowStyles.Add(new RowStyle());
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMain.RowStyles.Add(new RowStyle());
            tlpMain.Size = new Size(895, 627);
            tlpMain.TabIndex = 39;
            // 
            // tabControl
            // 
            tlpMain.SetColumnSpan(tabControl, 4);
            tabControl.Controls.Add(tabListView);
            tabControl.Controls.Add(tabBrowse);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 29);
            tabControl.Margin = new Padding(0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(895, 567);
            tabControl.TabIndex = 38;
            tabControl.SelectedIndexChanged += RefreshCurrentList;
            // 
            // tabListView
            // 
            tabListView.BackColor = SystemColors.Control;
            tabListView.Controls.Add(tlpWeapon);
            tabListView.Location = new Point(4, 24);
            tabListView.Margin = new Padding(4, 3, 4, 3);
            tabListView.Name = "tabListView";
            tabListView.Padding = new Padding(4, 3, 4, 3);
            tabListView.Size = new Size(887, 539);
            tabListView.TabIndex = 1;
            tabListView.Tag = "Title_ListView";
            tabListView.Text = "List View";
            // 
            // tlpWeapon
            // 
            tlpWeapon.AutoSize = true;
            tlpWeapon.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpWeapon.ColumnCount = 2;
            tlpWeapon.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tlpWeapon.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tlpWeapon.Controls.Add(lstWeapon, 0, 0);
            tlpWeapon.Controls.Add(tlpRight, 1, 0);
            tlpWeapon.Controls.Add(tlpBottomRight, 1, 1);
            tlpWeapon.Dock = DockStyle.Fill;
            tlpWeapon.Location = new Point(4, 3);
            tlpWeapon.Margin = new Padding(4, 3, 4, 3);
            tlpWeapon.Name = "tlpWeapon";
            tlpWeapon.RowCount = 2;
            tlpWeapon.RowStyles.Add(new RowStyle());
            tlpWeapon.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpWeapon.Size = new Size(879, 533);
            tlpWeapon.TabIndex = 71;
            // 
            // lstWeapon
            // 
            lstWeapon.Dock = DockStyle.Fill;
            lstWeapon.FormattingEnabled = true;
            lstWeapon.Location = new Point(4, 3);
            lstWeapon.Margin = new Padding(4, 3, 4, 3);
            lstWeapon.Name = "lstWeapon";
            tlpWeapon.SetRowSpan(lstWeapon, 2);
            lstWeapon.Size = new Size(343, 527);
            lstWeapon.TabIndex = 66;
            lstWeapon.SelectedIndexChanged += lstWeapon_SelectedIndexChanged;
            lstWeapon.DoubleClick += cmdOK_Click;
            // 
            // tlpRight
            // 
            tlpRight.AutoSize = true;
            tlpRight.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpRight.ColumnCount = 4;
            tlpRight.ColumnStyles.Add(new ColumnStyle());
            tlpRight.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpRight.ColumnStyles.Add(new ColumnStyle());
            tlpRight.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpRight.Controls.Add(lblWeaponConceal, 1, 3);
            tlpRight.Controls.Add(lblSourceLabel, 0, 7);
            tlpRight.Controls.Add(lblWeaponDamageLabel, 0, 0);
            tlpRight.Controls.Add(lblWeaponConcealLabel, 0, 3);
            tlpRight.Controls.Add(lblWeaponDamage, 1, 0);
            tlpRight.Controls.Add(lblWeaponRCLabel, 2, 0);
            tlpRight.Controls.Add(flpMarkup, 3, 5);
            tlpRight.Controls.Add(lblMarkupLabel, 2, 5);
            tlpRight.Controls.Add(flpCheckBoxes, 0, 6);
            tlpRight.Controls.Add(lblWeaponMode, 3, 2);
            tlpRight.Controls.Add(lblWeaponCost, 1, 5);
            tlpRight.Controls.Add(lblWeaponCostLabel, 0, 5);
            tlpRight.Controls.Add(lblWeaponAmmo, 3, 1);
            tlpRight.Controls.Add(lblWeaponModeLabel, 2, 2);
            tlpRight.Controls.Add(lblWeaponReach, 1, 2);
            tlpRight.Controls.Add(lblTest, 3, 4);
            tlpRight.Controls.Add(lblTestLabel, 2, 4);
            tlpRight.Controls.Add(lblWeaponAvail, 1, 4);
            tlpRight.Controls.Add(lblWeaponAvailLabel, 0, 4);
            tlpRight.Controls.Add(lblWeaponReachLabel, 0, 2);
            tlpRight.Controls.Add(lblWeaponAmmoLabel, 2, 1);
            tlpRight.Controls.Add(lblWeaponAPLabel, 0, 1);
            tlpRight.Controls.Add(lblWeaponAccuracyLabel, 2, 3);
            tlpRight.Controls.Add(lblWeaponAccuracy, 3, 3);
            tlpRight.Controls.Add(lblWeaponAP, 1, 1);
            tlpRight.Dock = DockStyle.Fill;
            tlpRight.Location = new Point(351, 0);
            tlpRight.Margin = new Padding(0);
            tlpRight.Name = "tlpRight";
            tlpRight.RowCount = 8;
            tlpRight.RowStyles.Add(new RowStyle());
            tlpRight.RowStyles.Add(new RowStyle());
            tlpRight.RowStyles.Add(new RowStyle());
            tlpRight.RowStyles.Add(new RowStyle());
            tlpRight.RowStyles.Add(new RowStyle());
            tlpRight.RowStyles.Add(new RowStyle());
            tlpRight.RowStyles.Add(new RowStyle());
            tlpRight.RowStyles.Add(new RowStyle());
            tlpRight.Size = new Size(528, 203);
            tlpRight.TabIndex = 77;
            // 
            // lblWeaponConceal
            // 
            lblWeaponConceal.Anchor = AnchorStyles.Left;
            lblWeaponConceal.AutoSize = true;
            lblWeaponConceal.Location = new Point(66, 94);
            lblWeaponConceal.Margin = new Padding(4, 7, 4, 7);
            lblWeaponConceal.Name = "lblWeaponConceal";
            lblWeaponConceal.Size = new Size(58, 15);
            lblWeaponConceal.TabIndex = 76;
            lblWeaponConceal.Text = "[Conceal]";
            lblWeaponConceal.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblSourceLabel
            // 
            lblSourceLabel.Anchor = AnchorStyles.Right;
            lblSourceLabel.AutoSize = true;
            lblSourceLabel.Location = new Point(12, 181);
            lblSourceLabel.Margin = new Padding(4, 7, 4, 7);
            lblSourceLabel.Name = "lblSourceLabel";
            lblSourceLabel.Size = new Size(46, 15);
            lblSourceLabel.TabIndex = 64;
            lblSourceLabel.Tag = "Label_Source";
            lblSourceLabel.Text = "Source:";
            lblSourceLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblWeaponDamageLabel
            // 
            lblWeaponDamageLabel.Anchor = AnchorStyles.Right;
            lblWeaponDamageLabel.AutoSize = true;
            lblWeaponDamageLabel.Location = new Point(4, 7);
            lblWeaponDamageLabel.Margin = new Padding(4, 7, 4, 7);
            lblWeaponDamageLabel.Name = "lblWeaponDamageLabel";
            lblWeaponDamageLabel.Size = new Size(54, 15);
            lblWeaponDamageLabel.TabIndex = 40;
            lblWeaponDamageLabel.Tag = "Label_Damage";
            lblWeaponDamageLabel.Text = "Damage:";
            lblWeaponDamageLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblWeaponConcealLabel
            // 
            lblWeaponConcealLabel.Anchor = AnchorStyles.Right;
            lblWeaponConcealLabel.AutoSize = true;
            lblWeaponConcealLabel.Location = new Point(5, 94);
            lblWeaponConcealLabel.Margin = new Padding(4, 7, 4, 7);
            lblWeaponConcealLabel.Name = "lblWeaponConcealLabel";
            lblWeaponConcealLabel.Size = new Size(53, 15);
            lblWeaponConcealLabel.TabIndex = 75;
            lblWeaponConcealLabel.Tag = "Label_Conceal";
            lblWeaponConcealLabel.Text = "Conceal:";
            lblWeaponConcealLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblWeaponDamage
            // 
            lblWeaponDamage.Anchor = AnchorStyles.Left;
            lblWeaponDamage.AutoSize = true;
            lblWeaponDamage.Location = new Point(66, 7);
            lblWeaponDamage.Margin = new Padding(4, 7, 4, 7);
            lblWeaponDamage.Name = "lblWeaponDamage";
            lblWeaponDamage.Size = new Size(59, 15);
            lblWeaponDamage.TabIndex = 41;
            lblWeaponDamage.Text = "[Damage]";
            lblWeaponDamage.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblWeaponRCLabel
            // 
            lblWeaponRCLabel.Anchor = AnchorStyles.Right;
            lblWeaponRCLabel.AutoSize = true;
            lblWeaponRCLabel.Location = new Point(299, 7);
            lblWeaponRCLabel.Margin = new Padding(4, 7, 4, 7);
            lblWeaponRCLabel.Name = "lblWeaponRCLabel";
            lblWeaponRCLabel.Size = new Size(25, 15);
            lblWeaponRCLabel.TabIndex = 42;
            lblWeaponRCLabel.Tag = "Label_RC";
            lblWeaponRCLabel.Text = "RC:";
            lblWeaponRCLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // flpMarkup
            // 
            flpMarkup.Anchor = AnchorStyles.Left;
            flpMarkup.AutoSize = true;
            flpMarkup.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpMarkup.Controls.Add(nudMarkup);
            flpMarkup.Controls.Add(lblMarkupPercentLabel);
            flpMarkup.Location = new Point(328, 145);
            flpMarkup.Margin = new Padding(0);
            flpMarkup.Name = "flpMarkup";
            flpMarkup.Size = new Size(87, 29);
            flpMarkup.TabIndex = 72;
            flpMarkup.WrapContents = false;
            // 
            // nudMarkup
            // 
            nudMarkup.Anchor = AnchorStyles.Left;
            nudMarkup.AutoSize = true;
            nudMarkup.DecimalPlaces = 2;
            nudMarkup.Location = new Point(3, 3);
            nudMarkup.Name = "nudMarkup";
            nudMarkup.Size = new Size(56, 23);
            nudMarkup.TabIndex = 60;
            nudMarkup.ValueChanged += nudMarkup_ValueChanged;
            // 
            // lblMarkupPercentLabel
            // 
            lblMarkupPercentLabel.Anchor = AnchorStyles.Left;
            lblMarkupPercentLabel.AutoSize = true;
            lblMarkupPercentLabel.Location = new Point(66, 7);
            lblMarkupPercentLabel.Margin = new Padding(4, 7, 4, 7);
            lblMarkupPercentLabel.Name = "lblMarkupPercentLabel";
            lblMarkupPercentLabel.Size = new Size(17, 15);
            lblMarkupPercentLabel.TabIndex = 61;
            lblMarkupPercentLabel.Text = "%";
            lblMarkupPercentLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblMarkupLabel
            // 
            lblMarkupLabel.Anchor = AnchorStyles.Right;
            lblMarkupLabel.AutoSize = true;
            lblMarkupLabel.Location = new Point(273, 152);
            lblMarkupLabel.Margin = new Padding(4, 7, 4, 7);
            lblMarkupLabel.Name = "lblMarkupLabel";
            lblMarkupLabel.Size = new Size(51, 15);
            lblMarkupLabel.TabIndex = 59;
            lblMarkupLabel.Tag = "Label_SelectGear_Markup";
            lblMarkupLabel.Text = "Markup:";
            lblMarkupLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // flpCheckBoxes
            // 
            flpCheckBoxes.Anchor = AnchorStyles.Left;
            flpCheckBoxes.AutoSize = true;
            flpCheckBoxes.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpRight.SetColumnSpan(flpCheckBoxes, 4);
            flpCheckBoxes.Location = new Point(0, 174);
            flpCheckBoxes.Margin = new Padding(0);
            flpCheckBoxes.Name = "flpCheckBoxes";
            flpCheckBoxes.Size = new Size(0, 0);
            flpCheckBoxes.TabIndex = 73;
            // 
            // lblWeaponMode
            // 
            lblWeaponMode.Anchor = AnchorStyles.Left;
            lblWeaponMode.AutoSize = true;
            lblWeaponMode.Location = new Point(332, 65);
            lblWeaponMode.Margin = new Padding(4, 7, 4, 7);
            lblWeaponMode.Name = "lblWeaponMode";
            lblWeaponMode.Size = new Size(46, 15);
            lblWeaponMode.TabIndex = 51;
            lblWeaponMode.Text = "[Mode]";
            lblWeaponMode.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblWeaponCost
            // 
            lblWeaponCost.Anchor = AnchorStyles.Left;
            lblWeaponCost.AutoSize = true;
            lblWeaponCost.Location = new Point(66, 152);
            lblWeaponCost.Margin = new Padding(4, 7, 4, 7);
            lblWeaponCost.Name = "lblWeaponCost";
            lblWeaponCost.Size = new Size(39, 15);
            lblWeaponCost.TabIndex = 57;
            lblWeaponCost.Text = "[Cost]";
            lblWeaponCost.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblWeaponCostLabel
            // 
            lblWeaponCostLabel.Anchor = AnchorStyles.Right;
            lblWeaponCostLabel.AutoSize = true;
            lblWeaponCostLabel.Location = new Point(24, 152);
            lblWeaponCostLabel.Margin = new Padding(4, 7, 4, 7);
            lblWeaponCostLabel.Name = "lblWeaponCostLabel";
            lblWeaponCostLabel.Size = new Size(34, 15);
            lblWeaponCostLabel.TabIndex = 56;
            lblWeaponCostLabel.Tag = "Label_Cost";
            lblWeaponCostLabel.Text = "Cost:";
            lblWeaponCostLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblWeaponAmmo
            // 
            lblWeaponAmmo.Anchor = AnchorStyles.Left;
            lblWeaponAmmo.AutoSize = true;
            lblWeaponAmmo.Location = new Point(332, 36);
            lblWeaponAmmo.Margin = new Padding(4, 7, 4, 7);
            lblWeaponAmmo.Name = "lblWeaponAmmo";
            lblWeaponAmmo.Size = new Size(52, 15);
            lblWeaponAmmo.TabIndex = 47;
            lblWeaponAmmo.Text = "[Ammo]";
            lblWeaponAmmo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblWeaponModeLabel
            // 
            lblWeaponModeLabel.Anchor = AnchorStyles.Right;
            lblWeaponModeLabel.AutoSize = true;
            lblWeaponModeLabel.Location = new Point(283, 65);
            lblWeaponModeLabel.Margin = new Padding(4, 7, 4, 7);
            lblWeaponModeLabel.Name = "lblWeaponModeLabel";
            lblWeaponModeLabel.Size = new Size(41, 15);
            lblWeaponModeLabel.TabIndex = 50;
            lblWeaponModeLabel.Tag = "Label_Mode";
            lblWeaponModeLabel.Text = "Mode:";
            lblWeaponModeLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblWeaponReach
            // 
            lblWeaponReach.Anchor = AnchorStyles.Left;
            lblWeaponReach.AutoSize = true;
            lblWeaponReach.Location = new Point(66, 65);
            lblWeaponReach.Margin = new Padding(4, 7, 4, 7);
            lblWeaponReach.Name = "lblWeaponReach";
            lblWeaponReach.Size = new Size(47, 15);
            lblWeaponReach.TabIndex = 49;
            lblWeaponReach.Text = "[Reach]";
            lblWeaponReach.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTest
            // 
            lblTest.Anchor = AnchorStyles.Left;
            lblTest.AutoSize = true;
            lblTest.Location = new Point(332, 123);
            lblTest.Margin = new Padding(4, 7, 4, 7);
            lblTest.Name = "lblTest";
            lblTest.Size = new Size(21, 15);
            lblTest.TabIndex = 55;
            lblTest.Text = "[0]";
            lblTest.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTestLabel
            // 
            lblTestLabel.Anchor = AnchorStyles.Right;
            lblTestLabel.AutoSize = true;
            lblTestLabel.Location = new Point(293, 123);
            lblTestLabel.Margin = new Padding(4, 7, 4, 7);
            lblTestLabel.Name = "lblTestLabel";
            lblTestLabel.Size = new Size(31, 15);
            lblTestLabel.TabIndex = 54;
            lblTestLabel.Tag = "Label_Test";
            lblTestLabel.Text = "Test:";
            lblTestLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblWeaponAvail
            // 
            lblWeaponAvail.Anchor = AnchorStyles.Left;
            lblWeaponAvail.AutoSize = true;
            lblWeaponAvail.Location = new Point(66, 123);
            lblWeaponAvail.Margin = new Padding(4, 7, 4, 7);
            lblWeaponAvail.Name = "lblWeaponAvail";
            lblWeaponAvail.Size = new Size(41, 15);
            lblWeaponAvail.TabIndex = 53;
            lblWeaponAvail.Text = "[Avail]";
            lblWeaponAvail.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblWeaponAvailLabel
            // 
            lblWeaponAvailLabel.Anchor = AnchorStyles.Right;
            lblWeaponAvailLabel.AutoSize = true;
            lblWeaponAvailLabel.Location = new Point(22, 123);
            lblWeaponAvailLabel.Margin = new Padding(4, 7, 4, 7);
            lblWeaponAvailLabel.Name = "lblWeaponAvailLabel";
            lblWeaponAvailLabel.Size = new Size(36, 15);
            lblWeaponAvailLabel.TabIndex = 52;
            lblWeaponAvailLabel.Tag = "Label_Avail";
            lblWeaponAvailLabel.Text = "Avail:";
            lblWeaponAvailLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblWeaponReachLabel
            // 
            lblWeaponReachLabel.Anchor = AnchorStyles.Right;
            lblWeaponReachLabel.AutoSize = true;
            lblWeaponReachLabel.Location = new Point(16, 65);
            lblWeaponReachLabel.Margin = new Padding(4, 7, 4, 7);
            lblWeaponReachLabel.Name = "lblWeaponReachLabel";
            lblWeaponReachLabel.Size = new Size(42, 15);
            lblWeaponReachLabel.TabIndex = 48;
            lblWeaponReachLabel.Tag = "Label_Reach";
            lblWeaponReachLabel.Text = "Reach:";
            lblWeaponReachLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblWeaponAmmoLabel
            // 
            lblWeaponAmmoLabel.Anchor = AnchorStyles.Right;
            lblWeaponAmmoLabel.AutoSize = true;
            lblWeaponAmmoLabel.Location = new Point(277, 36);
            lblWeaponAmmoLabel.Margin = new Padding(4, 7, 4, 7);
            lblWeaponAmmoLabel.Name = "lblWeaponAmmoLabel";
            lblWeaponAmmoLabel.Size = new Size(47, 15);
            lblWeaponAmmoLabel.TabIndex = 46;
            lblWeaponAmmoLabel.Tag = "Label_Ammo";
            lblWeaponAmmoLabel.Text = "Ammo:";
            lblWeaponAmmoLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblWeaponAPLabel
            // 
            lblWeaponAPLabel.Anchor = AnchorStyles.Right;
            lblWeaponAPLabel.AutoSize = true;
            lblWeaponAPLabel.Location = new Point(33, 36);
            lblWeaponAPLabel.Margin = new Padding(4, 7, 4, 7);
            lblWeaponAPLabel.Name = "lblWeaponAPLabel";
            lblWeaponAPLabel.Size = new Size(25, 15);
            lblWeaponAPLabel.TabIndex = 44;
            lblWeaponAPLabel.Tag = "Label_AP";
            lblWeaponAPLabel.Text = "AP:";
            lblWeaponAPLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblWeaponAccuracyLabel
            // 
            lblWeaponAccuracyLabel.Anchor = AnchorStyles.Right;
            lblWeaponAccuracyLabel.AutoSize = true;
            lblWeaponAccuracyLabel.Location = new Point(265, 94);
            lblWeaponAccuracyLabel.Margin = new Padding(4, 7, 4, 7);
            lblWeaponAccuracyLabel.Name = "lblWeaponAccuracyLabel";
            lblWeaponAccuracyLabel.Size = new Size(59, 15);
            lblWeaponAccuracyLabel.TabIndex = 67;
            lblWeaponAccuracyLabel.Tag = "Label_Accuracy";
            lblWeaponAccuracyLabel.Text = "Accuracy:";
            lblWeaponAccuracyLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblWeaponAccuracy
            // 
            lblWeaponAccuracy.Anchor = AnchorStyles.Left;
            lblWeaponAccuracy.AutoSize = true;
            lblWeaponAccuracy.Location = new Point(332, 94);
            lblWeaponAccuracy.Margin = new Padding(4, 7, 4, 7);
            lblWeaponAccuracy.Name = "lblWeaponAccuracy";
            lblWeaponAccuracy.Size = new Size(64, 15);
            lblWeaponAccuracy.TabIndex = 68;
            lblWeaponAccuracy.Text = "[Accuracy]";
            lblWeaponAccuracy.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblWeaponAP
            // 
            lblWeaponAP.Anchor = AnchorStyles.Left;
            lblWeaponAP.AutoSize = true;
            lblWeaponAP.Location = new Point(66, 36);
            lblWeaponAP.Margin = new Padding(4, 7, 4, 7);
            lblWeaponAP.Name = "lblWeaponAP";
            lblWeaponAP.Size = new Size(30, 15);
            lblWeaponAP.TabIndex = 45;
            lblWeaponAP.Text = "[AP]";
            lblWeaponAP.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tlpBottomRight
            // 
            tlpBottomRight.AutoSize = true;
            tlpBottomRight.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpBottomRight.ColumnCount = 1;
            tlpBottomRight.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpBottomRight.Controls.Add(gpbIncludedAccessories, 0, 0);
            tlpBottomRight.Dock = DockStyle.Fill;
            tlpBottomRight.Location = new Point(351, 203);
            tlpBottomRight.Margin = new Padding(0);
            tlpBottomRight.Name = "tlpBottomRight";
            tlpBottomRight.RowCount = 3;
            tlpBottomRight.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpBottomRight.RowStyles.Add(new RowStyle());
            tlpBottomRight.RowStyles.Add(new RowStyle());
            tlpBottomRight.Size = new Size(528, 330);
            tlpBottomRight.TabIndex = 78;
            // 
            // gpbIncludedAccessories
            // 
            gpbIncludedAccessories.AutoSize = true;
            gpbIncludedAccessories.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            gpbIncludedAccessories.Controls.Add(pnlIncludedAccessories);
            gpbIncludedAccessories.Dock = DockStyle.Fill;
            gpbIncludedAccessories.Location = new Point(4, 3);
            gpbIncludedAccessories.Margin = new Padding(4, 3, 4, 3);
            gpbIncludedAccessories.Name = "gpbIncludedAccessories";
            gpbIncludedAccessories.Padding = new Padding(4, 3, 4, 3);
            gpbIncludedAccessories.Size = new Size(520, 324);
            gpbIncludedAccessories.TabIndex = 74;
            gpbIncludedAccessories.TabStop = false;
            gpbIncludedAccessories.Tag = "Label_SelectWeapon_IncludedItems";
            gpbIncludedAccessories.Text = "Included Accessories and Modifications:";
            // 
            // pnlIncludedAccessories
            // 
            pnlIncludedAccessories.AutoScroll = true;
            pnlIncludedAccessories.AutoScrollMinSize = new Size(0, 60);
            pnlIncludedAccessories.Controls.Add(lblIncludedAccessories);
            pnlIncludedAccessories.Dock = DockStyle.Fill;
            pnlIncludedAccessories.Location = new Point(4, 19);
            pnlIncludedAccessories.Margin = new Padding(4, 3, 4, 3);
            pnlIncludedAccessories.Name = "pnlIncludedAccessories";
            pnlIncludedAccessories.Padding = new Padding(4, 7, 15, 7);
            pnlIncludedAccessories.Size = new Size(512, 302);
            pnlIncludedAccessories.TabIndex = 0;
            // 
            // lblIncludedAccessories
            // 
            lblIncludedAccessories.AutoSize = true;
            lblIncludedAccessories.Location = new Point(4, 7);
            lblIncludedAccessories.Margin = new Padding(4, 0, 4, 0);
            lblIncludedAccessories.Name = "lblIncludedAccessories";
            lblIncludedAccessories.Size = new Size(44, 15);
            lblIncludedAccessories.TabIndex = 63;
            lblIncludedAccessories.Text = "[None]";
            // 
            // tabBrowse
            // 
            tabBrowse.BackColor = SystemColors.Control;
            tabBrowse.Controls.Add(dgvWeapons);
            tabBrowse.Location = new Point(4, 24);
            tabBrowse.Margin = new Padding(4, 3, 4, 3);
            tabBrowse.Name = "tabBrowse";
            tabBrowse.Padding = new Padding(4, 3, 4, 3);
            tabBrowse.Size = new Size(886, 529);
            tabBrowse.TabIndex = 0;
            tabBrowse.Tag = "Title_Browse";
            tabBrowse.Text = "Browse";
            // 
            // dgvWeapons
            // 
            dgvWeapons.AllowUserToAddRows = false;
            dgvWeapons.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = SystemColors.ControlLight;
            dgvWeapons.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvWeapons.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvWeapons.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvWeapons.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvWeapons.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvWeapons.Columns.AddRange(new DataGridViewColumn[] { dgvc_Guid, dgvc_Name, dgvc_Dice, dgvc_Accuracy, dgvc_Damage, dgvc_AP, dgvc_RC, dgvc_Ammo, dgvc_Mode, dgvc_Reach, dgvc_Conceal, dgvc_Accessories, Label_Avail, Label_Source, dgvc_Cost });
            dgvWeapons.Dock = DockStyle.Fill;
            dgvWeapons.Location = new Point(4, 3);
            dgvWeapons.Margin = new Padding(4, 3, 4, 3);
            dgvWeapons.MultiSelect = false;
            dgvWeapons.Name = "dgvWeapons";
            dgvWeapons.ReadOnly = true;
            dgvWeapons.RowHeadersVisible = false;
            dgvWeapons.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
            dgvWeapons.RowTemplate.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvWeapons.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvWeapons.Size = new Size(878, 523);
            dgvWeapons.TabIndex = 36;
            dgvWeapons.DoubleClick += cmdOK_Click;
            // 
            // dgvc_Guid
            // 
            dgvc_Guid.DataPropertyName = "WeaponGuid";
            dgvc_Guid.HeaderText = "dgvc_Guid";
            dgvc_Guid.Name = "dgvc_Guid";
            dgvc_Guid.ReadOnly = true;
            dgvc_Guid.Resizable = DataGridViewTriState.True;
            dgvc_Guid.Visible = false;
            // 
            // dgvc_Name
            // 
            dgvc_Name.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvc_Name.DataPropertyName = "WeaponName";
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvc_Name.DefaultCellStyle = dataGridViewCellStyle3;
            dgvc_Name.HeaderText = "Name";
            dgvc_Name.Name = "dgvc_Name";
            dgvc_Name.ReadOnly = true;
            dgvc_Name.Resizable = DataGridViewTriState.True;
            dgvc_Name.Width = 64;
            // 
            // dgvc_Dice
            // 
            dgvc_Dice.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvc_Dice.DataPropertyName = "Dice";
            dgvc_Dice.FillWeight = 30F;
            dgvc_Dice.HeaderText = "Dice Pool";
            dgvc_Dice.Name = "dgvc_Dice";
            dgvc_Dice.ReadOnly = true;
            dgvc_Dice.Resizable = DataGridViewTriState.True;
            dgvc_Dice.Width = 82;
            // 
            // dgvc_Accuracy
            // 
            dgvc_Accuracy.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvc_Accuracy.DataPropertyName = "Accuracy";
            dgvc_Accuracy.FillWeight = 50F;
            dgvc_Accuracy.HeaderText = "Accuracy";
            dgvc_Accuracy.Name = "dgvc_Accuracy";
            dgvc_Accuracy.ReadOnly = true;
            dgvc_Accuracy.Resizable = DataGridViewTriState.True;
            dgvc_Accuracy.Width = 81;
            // 
            // dgvc_Damage
            // 
            dgvc_Damage.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvc_Damage.DataPropertyName = "Damage";
            dgvc_Damage.FillWeight = 50F;
            dgvc_Damage.HeaderText = "Damage";
            dgvc_Damage.Name = "dgvc_Damage";
            dgvc_Damage.ReadOnly = true;
            dgvc_Damage.Resizable = DataGridViewTriState.True;
            dgvc_Damage.Width = 76;
            // 
            // dgvc_AP
            // 
            dgvc_AP.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvc_AP.DataPropertyName = "AP";
            dgvc_AP.FillWeight = 30F;
            dgvc_AP.HeaderText = "AP";
            dgvc_AP.Name = "dgvc_AP";
            dgvc_AP.ReadOnly = true;
            dgvc_AP.Resizable = DataGridViewTriState.True;
            dgvc_AP.Width = 47;
            // 
            // dgvc_RC
            // 
            dgvc_RC.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvc_RC.DataPropertyName = "RC";
            dgvc_RC.FillWeight = 30F;
            dgvc_RC.HeaderText = "RC";
            dgvc_RC.Name = "dgvc_RC";
            dgvc_RC.ReadOnly = true;
            dgvc_RC.Resizable = DataGridViewTriState.True;
            dgvc_RC.Width = 47;
            // 
            // dgvc_Ammo
            // 
            dgvc_Ammo.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvc_Ammo.DataPropertyName = "Ammo";
            dgvc_Ammo.FillWeight = 60F;
            dgvc_Ammo.HeaderText = "Ammo";
            dgvc_Ammo.Name = "dgvc_Ammo";
            dgvc_Ammo.ReadOnly = true;
            dgvc_Ammo.Resizable = DataGridViewTriState.True;
            dgvc_Ammo.Width = 69;
            // 
            // dgvc_Mode
            // 
            dgvc_Mode.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvc_Mode.DataPropertyName = "Mode";
            dgvc_Mode.FillWeight = 60F;
            dgvc_Mode.HeaderText = "Mode";
            dgvc_Mode.Name = "dgvc_Mode";
            dgvc_Mode.ReadOnly = true;
            dgvc_Mode.Resizable = DataGridViewTriState.True;
            dgvc_Mode.Width = 63;
            // 
            // dgvc_Reach
            // 
            dgvc_Reach.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvc_Reach.DataPropertyName = "Reach";
            dgvc_Reach.FillWeight = 40F;
            dgvc_Reach.HeaderText = "Reach";
            dgvc_Reach.Name = "dgvc_Reach";
            dgvc_Reach.ReadOnly = true;
            dgvc_Reach.Resizable = DataGridViewTriState.True;
            dgvc_Reach.Width = 64;
            // 
            // dgvc_Conceal
            // 
            dgvc_Conceal.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvc_Conceal.DataPropertyName = "Concealability";
            dgvc_Conceal.FillWeight = 50F;
            dgvc_Conceal.HeaderText = "Conceal";
            dgvc_Conceal.Name = "dgvc_Conceal";
            dgvc_Conceal.ReadOnly = true;
            dgvc_Conceal.Resizable = DataGridViewTriState.True;
            dgvc_Conceal.Width = 75;
            // 
            // dgvc_Accessories
            // 
            dgvc_Accessories.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvc_Accessories.DataPropertyName = "Accessories";
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvc_Accessories.DefaultCellStyle = dataGridViewCellStyle4;
            dgvc_Accessories.HeaderText = "Accessories";
            dgvc_Accessories.Name = "dgvc_Accessories";
            dgvc_Accessories.ReadOnly = true;
            dgvc_Accessories.Resizable = DataGridViewTriState.True;
            dgvc_Accessories.Width = 93;
            // 
            // Label_Avail
            // 
            Label_Avail.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Label_Avail.DataPropertyName = "Avail";
            Label_Avail.FillWeight = 30F;
            Label_Avail.HeaderText = "Avail";
            Label_Avail.Name = "Label_Avail";
            Label_Avail.ReadOnly = true;
            Label_Avail.Resizable = DataGridViewTriState.True;
            Label_Avail.Width = 58;
            // 
            // Label_Source
            // 
            Label_Source.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Label_Source.DataPropertyName = "Source";
            Label_Source.HeaderText = "Source";
            Label_Source.Name = "Label_Source";
            Label_Source.ReadOnly = true;
            Label_Source.Resizable = DataGridViewTriState.True;
            Label_Source.Width = 68;
            // 
            // dgvc_Cost
            // 
            dgvc_Cost.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvc_Cost.DataPropertyName = "Cost";
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle5.Format = "#,0.##¥";
            dataGridViewCellStyle5.NullValue = null;
            dgvc_Cost.DefaultCellStyle = dataGridViewCellStyle5;
            dgvc_Cost.FillWeight = 60F;
            dgvc_Cost.HeaderText = "Cost";
            dgvc_Cost.Name = "dgvc_Cost";
            dgvc_Cost.ReadOnly = true;
            dgvc_Cost.Resizable = DataGridViewTriState.True;
            dgvc_Cost.Width = 56;
            // 
            // lblCategory
            // 
            lblCategory.Anchor = AnchorStyles.Right;
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(4, 7);
            lblCategory.Margin = new Padding(4, 7, 4, 7);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(58, 15);
            lblCategory.TabIndex = 29;
            lblCategory.Tag = "Label_Category";
            lblCategory.Text = "Category:";
            lblCategory.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cboCategory
            // 
            cboCategory.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.FormattingEnabled = true;
            cboCategory.Location = new Point(70, 3);
            cboCategory.Margin = new Padding(4, 3, 4, 3);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(380, 23);
            cboCategory.TabIndex = 30;
            cboCategory.SelectedIndexChanged += RefreshCurrentList;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Location = new Point(511, 3);
            txtSearch.Margin = new Padding(4, 3, 4, 3);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(380, 23);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            txtSearch.KeyDown += txtSearch_KeyDown;
            txtSearch.KeyUp += txtSearch_KeyUp;
            // 
            // lblSearchLabel
            // 
            lblSearchLabel.Anchor = AnchorStyles.Right;
            lblSearchLabel.AutoSize = true;
            lblSearchLabel.Location = new Point(458, 7);
            lblSearchLabel.Margin = new Padding(4, 7, 4, 7);
            lblSearchLabel.Name = "lblSearchLabel";
            lblSearchLabel.Size = new Size(45, 15);
            lblSearchLabel.TabIndex = 0;
            lblSearchLabel.Tag = "Label_Search";
            lblSearchLabel.Text = "&Search:";
            lblSearchLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tlpButtons
            // 
            tlpButtons.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            tlpButtons.AutoSize = true;
            tlpButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpButtons.ColumnCount = 3;
            tlpMain.SetColumnSpan(tlpButtons, 4);
            tlpButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tlpButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tlpButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tlpButtons.Controls.Add(cmdCancel, 0, 0);
            tlpButtons.Controls.Add(cmdOKAdd, 1, 0);
            tlpButtons.Controls.Add(cmdOK, 2, 0);
            tlpButtons.Location = new Point(592, 596);
            tlpButtons.Margin = new Padding(0);
            tlpButtons.Name = "tlpButtons";
            tlpButtons.RowCount = 1;
            tlpButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpButtons.Size = new Size(303, 31);
            tlpButtons.TabIndex = 40;
            // 
            // cmdOKAdd
            // 
            cmdOKAdd.AutoSize = true;
            cmdOKAdd.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            cmdOKAdd.Dock = DockStyle.Fill;
            cmdOKAdd.Location = new Point(104, 3);
            cmdOKAdd.Margin = new Padding(4, 3, 4, 3);
            cmdOKAdd.MinimumSize = new Size(93, 0);
            cmdOKAdd.Name = "cmdOKAdd";
            cmdOKAdd.Size = new Size(93, 25);
            cmdOKAdd.TabIndex = 32;
            cmdOKAdd.Tag = "String_AddMore";
            cmdOKAdd.Text = "&Add && More";
            cmdOKAdd.UseVisualStyleBackColor = true;
            cmdOKAdd.Click += cmdOKAdd_Click;
            // 
            // SelectWeapon
            // 
            AcceptButton = cmdOK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            CancelButton = cmdCancel;
            ClientSize = new Size(915, 647);
            Controls.Add(tlpMain);
            DoubleBuffered = true;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SelectWeapon";
            Padding = new Padding(10, 10, 10, 10);
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Tag = "Title_SelectWeapon";
            Text = "Select Weapon";
            FormClosing += SelectWeapon_Closing;
            Load += SelectWeapon_Load;
            tlpMain.ResumeLayout(false);
            tlpMain.PerformLayout();
            tabControl.ResumeLayout(false);
            tabListView.ResumeLayout(false);
            tabListView.PerformLayout();
            tlpWeapon.ResumeLayout(false);
            tlpWeapon.PerformLayout();
            tlpRight.ResumeLayout(false);
            tlpRight.PerformLayout();
            flpMarkup.ResumeLayout(false);
            flpMarkup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudMarkup).EndInit();
            tlpBottomRight.ResumeLayout(false);
            tlpBottomRight.PerformLayout();
            gpbIncludedAccessories.ResumeLayout(false);
            pnlIncludedAccessories.ResumeLayout(false);
            pnlIncludedAccessories.PerformLayout();
            tabBrowse.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvWeapons).EndInit();
            tlpButtons.ResumeLayout(false);
            tlpButtons.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }
        #endregion

        private ElasticComboBox cboCategory;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearchLabel;
        private System.Windows.Forms.Button cmdOKAdd;
        private System.Windows.Forms.DataGridView dgvWeapons;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabBrowse;
        private System.Windows.Forms.TabPage tabListView;
        private Chummer.ColorableCheckBox chkBlackMarketDiscount;
        private System.Windows.Forms.Label lblWeaponAccuracy;
        private System.Windows.Forms.Label lblWeaponAccuracyLabel;
        private System.Windows.Forms.Label lblTest;
        private Chummer.NumericUpDownEx nudMarkup;
        private System.Windows.Forms.Label lblMarkupPercentLabel;
        private Chummer.ColorableCheckBox chkFreeItem;
        private LabelWithToolTip lblSource;
        private System.Windows.Forms.Label lblSourceLabel;
        private System.Windows.Forms.Label lblIncludedAccessories;
        private System.Windows.Forms.Label lblTestLabel;
        private System.Windows.Forms.Label lblMarkupLabel;
        private System.Windows.Forms.Label lblWeaponAmmo;
        private System.Windows.Forms.Label lblWeaponAmmoLabel;
        private System.Windows.Forms.Label lblWeaponMode;
        private System.Windows.Forms.Label lblWeaponModeLabel;
        private System.Windows.Forms.Label lblWeaponReach;
        private System.Windows.Forms.Label lblWeaponReachLabel;
        private System.Windows.Forms.Label lblWeaponAP;
        private System.Windows.Forms.Label lblWeaponAPLabel;
        private System.Windows.Forms.Label lblWeaponCost;
        private System.Windows.Forms.Label lblWeaponCostLabel;
        private System.Windows.Forms.Label lblWeaponAvail;
        private System.Windows.Forms.Label lblWeaponAvailLabel;
        private Chummer.LabelWithToolTip lblWeaponRC;
        private System.Windows.Forms.Label lblWeaponRCLabel;
        private System.Windows.Forms.Label lblWeaponDamage;
        private System.Windows.Forms.Label lblWeaponDamageLabel;
        private System.Windows.Forms.ListBox lstWeapon;
        private Chummer.ColorableCheckBox chkHideOverAvailLimit;
        private System.Windows.Forms.TableLayoutPanel tlpWeapon;
        private Chummer.ColorableCheckBox chkShowOnlyAffordItems;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.FlowLayoutPanel flpMarkup;
        private System.Windows.Forms.FlowLayoutPanel flpCheckBoxes;
        private System.Windows.Forms.GroupBox gpbIncludedAccessories;
        private System.Windows.Forms.Panel pnlIncludedAccessories;
        private System.Windows.Forms.Label lblWeaponConcealLabel;
        private System.Windows.Forms.Label lblWeaponConceal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvc_Guid;
        private DataGridViewTextBoxColumnTranslated dgvc_Name;
        private DataGridViewTextBoxColumnTranslated dgvc_Dice;
        private DataGridViewTextBoxColumnTranslated dgvc_Accuracy;
        private DataGridViewTextBoxColumnTranslated dgvc_Damage;
        private DataGridViewTextBoxColumnTranslated dgvc_AP;
        private DataGridViewTextBoxColumnTranslated dgvc_RC;
        private DataGridViewTextBoxColumnTranslated dgvc_Ammo;
        private DataGridViewTextBoxColumnTranslated dgvc_Mode;
        private DataGridViewTextBoxColumnTranslated dgvc_Reach;
        private DataGridViewTextBoxColumnTranslated dgvc_Conceal;
        private DataGridViewTextBoxColumnTranslated dgvc_Accessories;
        private DataGridViewTextBoxColumnTranslated Label_Avail;
        private DataGridViewTextBoxColumnTranslated Label_Source;
        private DataGridViewTextBoxColumnTranslated dgvc_Cost;
        private System.Windows.Forms.TableLayoutPanel tlpButtons;
        private System.Windows.Forms.TableLayoutPanel tlpRight;
        private System.Windows.Forms.TableLayoutPanel tlpBottomRight;
    }
}
