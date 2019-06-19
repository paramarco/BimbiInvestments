/*
 * User: Korenev
 * Date: 20.09.2010
 * Time: 12:06
 * 
 */
namespace tslight
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.btn_Connect = new System.Windows.Forms.Button();
            this.txt_Status = new System.Windows.Forms.Label();
            this.txt_Connect = new System.Windows.Forms.Label();
            this.ctl_Connect = new System.Windows.Forms.Panel();
            this.ctl_Tabs = new System.Windows.Forms.TabControl();
            this.tabMyInstruments = new System.Windows.Forms.TabPage();
            this.removeInstrument = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridViewMyInstruments = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tab_Security = new System.Windows.Forms.TabPage();
            this.save2myInstruments = new System.Windows.Forms.Button();
            this.dg_Security = new System.Windows.Forms.DataGridView();
            this.security_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.security_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.security_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotsize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tab_Param = new System.Windows.Forms.TabPage();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOldPass = new System.Windows.Forms.TextBox();
            this.btnPassChange = new System.Windows.Forms.Button();
            this.checkHide = new System.Windows.Forms.CheckBox();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_Port = new System.Windows.Forms.Label();
            this.edt_Port = new System.Windows.Forms.TextBox();
            this.lbl_IP = new System.Windows.Forms.Label();
            this.edt_IP = new System.Windows.Forms.TextBox();
            this.lbl_Password = new System.Windows.Forms.Label();
            this.edt_Password = new System.Windows.Forms.TextBox();
            this.lbl_Login = new System.Windows.Forms.Label();
            this.edt_Login = new System.Windows.Forms.TextBox();
            this.txtBoxAns = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dg_takingPositions = new System.Windows.Forms.DataGridView();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dg_closingPositions = new System.Windows.Forms.DataGridView();
            this.label12 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.ctl_Connect.SuspendLayout();
            this.ctl_Tabs.SuspendLayout();
            this.tabMyInstruments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMyInstruments)).BeginInit();
            this.tab_Security.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Security)).BeginInit();
            this.tab_Param.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_takingPositions)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_closingPositions)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(523, 11);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(109, 22);
            this.btn_Connect.TabIndex = 0;
            this.btn_Connect.Text = "Подключить";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // txt_Status
            // 
            this.txt_Status.Location = new System.Drawing.Point(638, 13);
            this.txt_Status.Name = "txt_Status";
            this.txt_Status.Size = new System.Drawing.Size(191, 18);
            this.txt_Status.TabIndex = 1;
            // 
            // txt_Connect
            // 
            this.txt_Connect.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_Connect.ForeColor = System.Drawing.Color.Black;
            this.txt_Connect.Location = new System.Drawing.Point(3, 2);
            this.txt_Connect.Name = "txt_Connect";
            this.txt_Connect.Size = new System.Drawing.Size(86, 14);
            this.txt_Connect.TabIndex = 3;
            this.txt_Connect.Text = "offline";
            this.txt_Connect.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ctl_Connect
            // 
            this.ctl_Connect.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ctl_Connect.Controls.Add(this.txt_Connect);
            this.ctl_Connect.Location = new System.Drawing.Point(421, 12);
            this.ctl_Connect.Name = "ctl_Connect";
            this.ctl_Connect.Size = new System.Drawing.Size(96, 22);
            this.ctl_Connect.TabIndex = 4;
            // 
            // ctl_Tabs
            // 
            this.ctl_Tabs.Controls.Add(this.tabMyInstruments);
            this.ctl_Tabs.Controls.Add(this.tab_Security);
            this.ctl_Tabs.Controls.Add(this.tab_Param);
            this.ctl_Tabs.Location = new System.Drawing.Point(11, 12);
            this.ctl_Tabs.Name = "ctl_Tabs";
            this.ctl_Tabs.SelectedIndex = 0;
            this.ctl_Tabs.Size = new System.Drawing.Size(386, 618);
            this.ctl_Tabs.TabIndex = 7;
            // 
            // tabMyInstruments
            // 
            this.tabMyInstruments.Controls.Add(this.removeInstrument);
            this.tabMyInstruments.Controls.Add(this.button4);
            this.tabMyInstruments.Controls.Add(this.dataGridViewMyInstruments);
            this.tabMyInstruments.Location = new System.Drawing.Point(4, 22);
            this.tabMyInstruments.Name = "tabMyInstruments";
            this.tabMyInstruments.Padding = new System.Windows.Forms.Padding(3);
            this.tabMyInstruments.Size = new System.Drawing.Size(378, 592);
            this.tabMyInstruments.TabIndex = 3;
            this.tabMyInstruments.Text = "мои инструменты";
            this.tabMyInstruments.UseVisualStyleBackColor = true;
            // 
            // removeInstrument
            // 
            this.removeInstrument.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.removeInstrument.ForeColor = System.Drawing.Color.Black;
            this.removeInstrument.Location = new System.Drawing.Point(149, 391);
            this.removeInstrument.Name = "removeInstrument";
            this.removeInstrument.Size = new System.Drawing.Size(137, 50);
            this.removeInstrument.TabIndex = 39;
            this.removeInstrument.Text = "стереть инструмент";
            this.removeInstrument.UseVisualStyleBackColor = true;
            this.removeInstrument.Click += new System.EventHandler(this.onRemoveInstrument_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Location = new System.Drawing.Point(6, 391);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(137, 50);
            this.button4.TabIndex = 38;
            this.button4.Text = "экономить";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dataGridViewMyInstruments
            // 
            this.dataGridViewMyInstruments.AllowDrop = true;
            this.dataGridViewMyInstruments.AllowUserToAddRows = false;
            this.dataGridViewMyInstruments.AllowUserToDeleteRows = false;
            this.dataGridViewMyInstruments.AllowUserToResizeRows = false;
            this.dataGridViewMyInstruments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMyInstruments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dataGridViewMyInstruments.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewMyInstruments.MultiSelect = false;
            this.dataGridViewMyInstruments.Name = "dataGridViewMyInstruments";
            this.dataGridViewMyInstruments.RowHeadersWidth = 20;
            this.dataGridViewMyInstruments.RowTemplate.Height = 18;
            this.dataGridViewMyInstruments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMyInstruments.Size = new System.Drawing.Size(366, 379);
            this.dataGridViewMyInstruments.TabIndex = 1;
            this.dataGridViewMyInstruments.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMyInstruments_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "security_id";
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "id";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 50;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "security_name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Название";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "security_code";
            this.dataGridViewTextBoxColumn3.HeaderText = "Код";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 50;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "lotsize";
            this.dataGridViewTextBoxColumn4.HeaderText = "Лот";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 30;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 50;
            // 
            // tab_Security
            // 
            this.tab_Security.Controls.Add(this.save2myInstruments);
            this.tab_Security.Controls.Add(this.dg_Security);
            this.tab_Security.Location = new System.Drawing.Point(4, 22);
            this.tab_Security.Name = "tab_Security";
            this.tab_Security.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Security.Size = new System.Drawing.Size(378, 592);
            this.tab_Security.TabIndex = 1;
            this.tab_Security.Text = "Инструменты";
            this.tab_Security.UseVisualStyleBackColor = true;
            // 
            // save2myInstruments
            // 
            this.save2myInstruments.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.save2myInstruments.ForeColor = System.Drawing.Color.Black;
            this.save2myInstruments.Location = new System.Drawing.Point(6, 389);
            this.save2myInstruments.Name = "save2myInstruments";
            this.save2myInstruments.Size = new System.Drawing.Size(137, 50);
            this.save2myInstruments.TabIndex = 39;
            this.save2myInstruments.Text = "добавить к моим инструментам";
            this.save2myInstruments.UseVisualStyleBackColor = true;
            this.save2myInstruments.Click += new System.EventHandler(this.save2myInstruments_Click);
            // 
            // dg_Security
            // 
            this.dg_Security.AllowDrop = true;
            this.dg_Security.AllowUserToAddRows = false;
            this.dg_Security.AllowUserToDeleteRows = false;
            this.dg_Security.AllowUserToResizeRows = false;
            this.dg_Security.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Security.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.security_id,
            this.security_name,
            this.security_code,
            this.lotsize});
            this.dg_Security.Location = new System.Drawing.Point(6, 6);
            this.dg_Security.MultiSelect = false;
            this.dg_Security.Name = "dg_Security";
            this.dg_Security.RowHeadersWidth = 20;
            this.dg_Security.RowTemplate.Height = 18;
            this.dg_Security.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Security.Size = new System.Drawing.Size(366, 377);
            this.dg_Security.TabIndex = 0;
            // 
            // security_id
            // 
            this.security_id.DataPropertyName = "security_id";
            this.security_id.Frozen = true;
            this.security_id.HeaderText = "id";
            this.security_id.MinimumWidth = 50;
            this.security_id.Name = "security_id";
            this.security_id.ReadOnly = true;
            this.security_id.Width = 50;
            // 
            // security_name
            // 
            this.security_name.DataPropertyName = "security_name";
            this.security_name.HeaderText = "Название";
            this.security_name.MinimumWidth = 100;
            this.security_name.Name = "security_name";
            this.security_name.ReadOnly = true;
            this.security_name.Width = 150;
            // 
            // security_code
            // 
            this.security_code.DataPropertyName = "security_code";
            this.security_code.HeaderText = "Код";
            this.security_code.MinimumWidth = 50;
            this.security_code.Name = "security_code";
            this.security_code.ReadOnly = true;
            // 
            // lotsize
            // 
            this.lotsize.DataPropertyName = "lotsize";
            this.lotsize.HeaderText = "Лот";
            this.lotsize.MinimumWidth = 30;
            this.lotsize.Name = "lotsize";
            this.lotsize.ReadOnly = true;
            this.lotsize.Width = 50;
            // 
            // tab_Param
            // 
            this.tab_Param.Controls.Add(this.comboBox1);
            this.tab_Param.Controls.Add(this.label1);
            this.tab_Param.Controls.Add(this.label4);
            this.tab_Param.Controls.Add(this.label3);
            this.tab_Param.Controls.Add(this.txtOldPass);
            this.tab_Param.Controls.Add(this.btnPassChange);
            this.tab_Param.Controls.Add(this.checkHide);
            this.tab_Param.Controls.Add(this.txtNewPass);
            this.tab_Param.Controls.Add(this.label2);
            this.tab_Param.Controls.Add(this.lbl_Port);
            this.tab_Param.Controls.Add(this.edt_Port);
            this.tab_Param.Controls.Add(this.lbl_IP);
            this.tab_Param.Controls.Add(this.edt_IP);
            this.tab_Param.Controls.Add(this.lbl_Password);
            this.tab_Param.Controls.Add(this.edt_Password);
            this.tab_Param.Controls.Add(this.lbl_Login);
            this.tab_Param.Controls.Add(this.edt_Login);
            this.tab_Param.Location = new System.Drawing.Point(4, 22);
            this.tab_Param.Name = "tab_Param";
            this.tab_Param.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Param.Size = new System.Drawing.Size(378, 592);
            this.tab_Param.TabIndex = 2;
            this.tab_Param.Text = "Параметры";
            this.tab_Param.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(135, 143);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(22, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 14);
            this.label1.TabIndex = 32;
            this.label1.Text = "рынок";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 326);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Новый";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 297);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Старый";
            // 
            // txtOldPass
            // 
            this.txtOldPass.Location = new System.Drawing.Point(78, 294);
            this.txtOldPass.Name = "txtOldPass";
            this.txtOldPass.PasswordChar = '*';
            this.txtOldPass.Size = new System.Drawing.Size(122, 20);
            this.txtOldPass.TabIndex = 29;
            // 
            // btnPassChange
            // 
            this.btnPassChange.Location = new System.Drawing.Point(78, 378);
            this.btnPassChange.Name = "btnPassChange";
            this.btnPassChange.Size = new System.Drawing.Size(75, 23);
            this.btnPassChange.TabIndex = 28;
            this.btnPassChange.Text = "Сменить";
            this.btnPassChange.UseVisualStyleBackColor = true;
            this.btnPassChange.Click += new System.EventHandler(this.btnPassChange_Click);
            // 
            // checkHide
            // 
            this.checkHide.AutoSize = true;
            this.checkHide.Checked = true;
            this.checkHide.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkHide.Location = new System.Drawing.Point(78, 350);
            this.checkHide.Name = "checkHide";
            this.checkHide.Size = new System.Drawing.Size(76, 17);
            this.checkHide.TabIndex = 27;
            this.checkHide.Text = "Скрывать";
            this.checkHide.UseVisualStyleBackColor = true;
            this.checkHide.CheckedChanged += new System.EventHandler(this.checkHide_CheckedChanged);
            // 
            // txtNewPass
            // 
            this.txtNewPass.Location = new System.Drawing.Point(78, 324);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.PasswordChar = '*';
            this.txtNewPass.Size = new System.Drawing.Size(122, 20);
            this.txtNewPass.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 262);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Смена пароля";
            // 
            // lbl_Port
            // 
            this.lbl_Port.Location = new System.Drawing.Point(22, 118);
            this.lbl_Port.Name = "lbl_Port";
            this.lbl_Port.Size = new System.Drawing.Size(100, 14);
            this.lbl_Port.TabIndex = 17;
            this.lbl_Port.Text = "Порт";
            // 
            // edt_Port
            // 
            this.edt_Port.Location = new System.Drawing.Point(135, 115);
            this.edt_Port.Name = "edt_Port";
            this.edt_Port.Size = new System.Drawing.Size(122, 20);
            this.edt_Port.TabIndex = 16;
            // 
            // lbl_IP
            // 
            this.lbl_IP.Location = new System.Drawing.Point(22, 92);
            this.lbl_IP.Name = "lbl_IP";
            this.lbl_IP.Size = new System.Drawing.Size(100, 14);
            this.lbl_IP.TabIndex = 13;
            this.lbl_IP.Text = "IP адрес";
            // 
            // edt_IP
            // 
            this.edt_IP.Location = new System.Drawing.Point(135, 89);
            this.edt_IP.Name = "edt_IP";
            this.edt_IP.Size = new System.Drawing.Size(122, 20);
            this.edt_IP.TabIndex = 12;
            // 
            // lbl_Password
            // 
            this.lbl_Password.Location = new System.Drawing.Point(22, 66);
            this.lbl_Password.Name = "lbl_Password";
            this.lbl_Password.Size = new System.Drawing.Size(100, 14);
            this.lbl_Password.TabIndex = 11;
            this.lbl_Password.Text = "Пароль";
            // 
            // edt_Password
            // 
            this.edt_Password.Location = new System.Drawing.Point(135, 63);
            this.edt_Password.Name = "edt_Password";
            this.edt_Password.Size = new System.Drawing.Size(122, 20);
            this.edt_Password.TabIndex = 10;
            this.edt_Password.UseSystemPasswordChar = true;
            // 
            // lbl_Login
            // 
            this.lbl_Login.Location = new System.Drawing.Point(22, 40);
            this.lbl_Login.Name = "lbl_Login";
            this.lbl_Login.Size = new System.Drawing.Size(100, 14);
            this.lbl_Login.TabIndex = 9;
            this.lbl_Login.Text = "Логин";
            // 
            // edt_Login
            // 
            this.edt_Login.Location = new System.Drawing.Point(135, 37);
            this.edt_Login.Name = "edt_Login";
            this.edt_Login.Size = new System.Drawing.Size(122, 20);
            this.edt_Login.TabIndex = 8;
            // 
            // txtBoxAns
            // 
            this.txtBoxAns.Location = new System.Drawing.Point(403, 513);
            this.txtBoxAns.Name = "txtBoxAns";
            this.txtBoxAns.Size = new System.Drawing.Size(741, 107);
            this.txtBoxAns.TabIndex = 26;
            this.txtBoxAns.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(509, 53);
            this.label5.MinimumSize = new System.Drawing.Size(160, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 44);
            this.label5.TabIndex = 28;
            this.label5.Tag = "";
            this.label5.Text = "0";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.Salmon;
            this.label6.Location = new System.Drawing.Point(844, 67);
            this.label6.MinimumSize = new System.Drawing.Size(60, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 30);
            this.label6.TabIndex = 29;
            this.label6.Tag = "";
            this.label6.Text = "продажа (take profit)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.Color.SeaGreen;
            this.label7.Location = new System.Drawing.Point(418, 118);
            this.label7.MinimumSize = new System.Drawing.Size(60, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 30);
            this.label7.TabIndex = 30;
            this.label7.Tag = "";
            this.label7.Text = "покупка";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.ForeColor = System.Drawing.Color.Navy;
            this.label9.Location = new System.Drawing.Point(418, 173);
            this.label9.MinimumSize = new System.Drawing.Size(60, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 30);
            this.label9.TabIndex = 32;
            this.label9.Tag = "";
            this.label9.Text = "дельта";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.ForeColor = System.Drawing.Color.Black;
            this.textBox1.Location = new System.Drawing.Point(517, 151);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(142, 50);
            this.textBox1.TabIndex = 33;
            this.textBox1.Text = "0.300";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.Color.Salmon;
            this.label8.Location = new System.Drawing.Point(844, 118);
            this.label8.MinimumSize = new System.Drawing.Size(60, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(135, 30);
            this.label8.TabIndex = 34;
            this.label8.Tag = "";
            this.label8.Text = "продажа (stop loss)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(990, 102);
            this.label10.MinimumSize = new System.Drawing.Size(160, 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(160, 44);
            this.label10.TabIndex = 35;
            this.label10.Tag = "";
            this.label10.Text = "0";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(990, 53);
            this.label11.MinimumSize = new System.Drawing.Size(160, 40);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(160, 44);
            this.label11.TabIndex = 36;
            this.label11.Tag = "";
            this.label11.Text = "0";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(522, 295);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 50);
            this.button1.TabIndex = 37;
            this.button1.Text = "отправить заказ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::tslight.Properties.Resources.grow;
            this.button2.Location = new System.Drawing.Point(694, 67);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 65);
            this.button2.TabIndex = 38;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(418, 67);
            this.label13.MinimumSize = new System.Drawing.Size(60, 30);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 30);
            this.label13.TabIndex = 39;
            this.label13.Tag = "";
            this.label13.Text = "текущая цена";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(509, 104);
            this.label14.MinimumSize = new System.Drawing.Size(160, 40);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(160, 44);
            this.label14.TabIndex = 40;
            this.label14.Tag = "";
            this.label14.Text = "0";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.ForeColor = System.Drawing.Color.Navy;
            this.label15.Location = new System.Drawing.Point(418, 229);
            this.label15.MinimumSize = new System.Drawing.Size(60, 30);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 30);
            this.label15.TabIndex = 41;
            this.label15.Tag = "";
            this.label15.Text = "лоты";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.ForeColor = System.Drawing.Color.Black;
            this.textBox2.Location = new System.Drawing.Point(517, 209);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(142, 50);
            this.textBox2.TabIndex = 42;
            this.textBox2.Text = "1";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Location = new System.Drawing.Point(686, 190);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(160, 80);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "коэффициент заказа";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox3.ForeColor = System.Drawing.Color.Black;
            this.textBox3.Location = new System.Drawing.Point(8, 19);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(142, 50);
            this.textBox3.TabIndex = 44;
            this.textBox3.Text = "1";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox4.ForeColor = System.Drawing.Color.Black;
            this.textBox4.Location = new System.Drawing.Point(8, 19);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(142, 50);
            this.textBox4.TabIndex = 44;
            this.textBox4.Text = "2";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Location = new System.Drawing.Point(840, 190);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(160, 80);
            this.groupBox2.TabIndex = 44;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "коэффициент стоп-лосса";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox5);
            this.groupBox3.Location = new System.Drawing.Point(991, 190);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(160, 80);
            this.groupBox3.TabIndex = 45;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Коэффициент ТейкПрофит";
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox5.ForeColor = System.Drawing.Color.Black;
            this.textBox5.Location = new System.Drawing.Point(8, 19);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(142, 50);
            this.textBox5.TabIndex = 44;
            this.textBox5.Text = "2";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Location = new System.Drawing.Point(689, 276);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(160, 80);
            this.groupBox4.TabIndex = 45;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "режим паники";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Gold;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(13, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(137, 50);
            this.button3.TabIndex = 46;
            this.button3.Text = "отменить все заказы";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dg_takingPositions);
            this.groupBox5.Location = new System.Drawing.Point(414, 382);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(346, 107);
            this.groupBox5.TabIndex = 46;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "taking position";
            // 
            // dg_takingPositions
            // 
            this.dg_takingPositions.AllowUserToAddRows = false;
            this.dg_takingPositions.AllowUserToDeleteRows = false;
            this.dg_takingPositions.AllowUserToOrderColumns = true;
            this.dg_takingPositions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_takingPositions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_takingPositions.Location = new System.Drawing.Point(3, 16);
            this.dg_takingPositions.Name = "dg_takingPositions";
            this.dg_takingPositions.ReadOnly = true;
            this.dg_takingPositions.RowHeadersVisible = false;
            this.dg_takingPositions.Size = new System.Drawing.Size(340, 88);
            this.dg_takingPositions.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dg_closingPositions);
            this.groupBox6.Location = new System.Drawing.Point(769, 382);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(382, 107);
            this.groupBox6.TabIndex = 47;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "closing position";
            // 
            // dg_closingPositions
            // 
            this.dg_closingPositions.AllowUserToAddRows = false;
            this.dg_closingPositions.AllowUserToDeleteRows = false;
            this.dg_closingPositions.AllowUserToOrderColumns = true;
            this.dg_closingPositions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_closingPositions.Location = new System.Drawing.Point(0, 16);
            this.dg_closingPositions.Name = "dg_closingPositions";
            this.dg_closingPositions.ReadOnly = true;
            this.dg_closingPositions.RowHeadersVisible = false;
            this.dg_closingPositions.Size = new System.Drawing.Size(381, 88);
            this.dg_closingPositions.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(827, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(155, 13);
            this.label12.TabIndex = 48;
            this.label12.Text = "синхронизировать с ксенией";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(984, 16);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(44, 17);
            this.checkBox1.TabIndex = 49;
            this.checkBox1.Text = "да  ";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Yellow;
            this.label16.ForeColor = System.Drawing.Color.Yellow;
            this.label16.Location = new System.Drawing.Point(1116, 18);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(15, 13);
            this.label16.TabIndex = 50;
            this.label16.Text = "la";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(1025, 17);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(89, 13);
            this.label17.TabIndex = 51;
            this.label17.Text = "сервер включен";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1156, 495);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txt_Status);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBoxAns);
            this.Controls.Add(this.ctl_Tabs);
            this.Controls.Add(this.btn_Connect);
            this.Controls.Add(this.ctl_Connect);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "торговая платформа  вимви v0.6";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.ctl_Connect.ResumeLayout(false);
            this.ctl_Tabs.ResumeLayout(false);
            this.tabMyInstruments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMyInstruments)).EndInit();
            this.tab_Security.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_Security)).EndInit();
            this.tab_Param.ResumeLayout(false);
            this.tab_Param.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_takingPositions)).EndInit();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_closingPositions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}


        private System.Windows.Forms.TextBox edt_Port;
		private System.Windows.Forms.Label lbl_Port;
		private System.Windows.Forms.TextBox edt_IP;
		private System.Windows.Forms.TextBox edt_Password;
        private System.Windows.Forms.TextBox edt_Login;
		private System.Windows.Forms.Label lbl_Login;
		private System.Windows.Forms.Label lbl_Password;
        private System.Windows.Forms.Label lbl_IP;
		private System.Windows.Forms.DataGridView dg_Security;
		private System.Windows.Forms.TabPage tab_Param;
		private System.Windows.Forms.TabPage tab_Security;
        private System.Windows.Forms.TabControl ctl_Tabs;
		private System.Windows.Forms.Panel ctl_Connect;
		private System.Windows.Forms.Label txt_Connect;
		private System.Windows.Forms.Label txt_Status;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.RichTextBox txtBoxAns;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOldPass;
        private System.Windows.Forms.Button btnPassChange;
        private System.Windows.Forms.CheckBox checkHide;
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn security_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn security_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn security_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotsize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TabPage tabMyInstruments;
        private System.Windows.Forms.DataGridView dataGridViewMyInstruments;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Button removeInstrument;
        private System.Windows.Forms.Button save2myInstruments;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView dg_takingPositions;
        private System.Windows.Forms.DataGridView dg_closingPositions;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
    }
}
