namespace PAW
{
    partial class AddEditForm
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numClientId = new System.Windows.Forms.NumericUpDown();
            this.phoneNo = new System.Windows.Forms.TextBox();
            this.firstName = new System.Windows.Forms.TextBox();
            this.lastName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.numAddressId = new System.Windows.Forms.NumericUpDown();
            this.apartment = new System.Windows.Forms.TextBox();
            this.floor = new System.Windows.Forms.TextBox();
            this.street = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.pizzaSize = new System.Windows.Forms.ComboBox();
            this.numPizzaId = new System.Windows.Forms.NumericUpDown();
            this.pizzaType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numClientId)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAddressId)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPizzaId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numClientId);
            this.groupBox1.Controls.Add(this.phoneNo);
            this.groupBox1.Controls.Add(this.firstName);
            this.groupBox1.Controls.Add(this.lastName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(26, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 151);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Client";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "ID";
            // 
            // numClientId
            // 
            this.numClientId.Location = new System.Drawing.Point(82, 32);
            this.numClientId.Name = "numClientId";
            this.numClientId.Size = new System.Drawing.Size(104, 22);
            this.numClientId.TabIndex = 8;
            this.numClientId.Validating += new System.ComponentModel.CancelEventHandler(this.numClientId_Validating);
            this.numClientId.Validated += new System.EventHandler(this.numClientId_Validated);
            // 
            // phoneNo
            // 
            this.phoneNo.Location = new System.Drawing.Point(82, 113);
            this.phoneNo.Name = "phoneNo";
            this.phoneNo.Size = new System.Drawing.Size(105, 22);
            this.phoneNo.TabIndex = 7;
            this.phoneNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.phoneNo_KeyPress);
            this.phoneNo.Validating += new System.ComponentModel.CancelEventHandler(this.phoneNo_Validating);
            this.phoneNo.Validated += new System.EventHandler(this.phoneNo_Validated);
            // 
            // firstName
            // 
            this.firstName.Location = new System.Drawing.Point(82, 87);
            this.firstName.Name = "firstName";
            this.firstName.Size = new System.Drawing.Size(105, 22);
            this.firstName.TabIndex = 6;
            this.firstName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lastName_KeyPress);
            this.firstName.Validating += new System.ComponentModel.CancelEventHandler(this.firstName_Validating);
            this.firstName.Validated += new System.EventHandler(this.firstName_Validated);
            // 
            // lastName
            // 
            this.lastName.Location = new System.Drawing.Point(82, 60);
            this.lastName.Name = "lastName";
            this.lastName.Size = new System.Drawing.Size(105, 22);
            this.lastName.TabIndex = 5;
            this.lastName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lastName_KeyPress);
            this.lastName.Validating += new System.ComponentModel.CancelEventHandler(this.lastName_Validating);
            this.lastName.Validated += new System.EventHandler(this.lastName_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Phone no.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Last name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "First name";
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(26, 495);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(70, 30);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(178, 495);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 30);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.numAddressId);
            this.groupBox3.Controls.Add(this.apartment);
            this.groupBox3.Controls.Add(this.floor);
            this.groupBox3.Controls.Add(this.street);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(26, 177);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(225, 178);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Address";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 16);
            this.label10.TabIndex = 11;
            this.label10.Text = "ID";
            // 
            // numAddressId
            // 
            this.numAddressId.Location = new System.Drawing.Point(82, 39);
            this.numAddressId.Name = "numAddressId";
            this.numAddressId.Size = new System.Drawing.Size(104, 22);
            this.numAddressId.TabIndex = 10;
            this.numAddressId.Validating += new System.ComponentModel.CancelEventHandler(this.numAddressId_Validating);
            this.numAddressId.Validated += new System.EventHandler(this.numAddressId_Validated);
            // 
            // apartment
            // 
            this.apartment.Location = new System.Drawing.Point(83, 123);
            this.apartment.Name = "apartment";
            this.apartment.Size = new System.Drawing.Size(105, 22);
            this.apartment.TabIndex = 7;
            this.apartment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.phoneNo_KeyPress);
            // 
            // floor
            // 
            this.floor.Location = new System.Drawing.Point(83, 97);
            this.floor.Name = "floor";
            this.floor.Size = new System.Drawing.Size(105, 22);
            this.floor.TabIndex = 6;
            this.floor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.phoneNo_KeyPress);
            // 
            // street
            // 
            this.street.Location = new System.Drawing.Point(83, 70);
            this.street.Name = "street";
            this.street.Size = new System.Drawing.Size(105, 22);
            this.street.TabIndex = 5;
            this.street.Validating += new System.ComponentModel.CancelEventHandler(this.lastName_Validating);
            this.street.Validated += new System.EventHandler(this.lastName_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 16);
            this.label6.TabIndex = 2;
            this.label6.Text = "Apartment";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 16);
            this.label7.TabIndex = 1;
            this.label7.Text = "Street";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 16);
            this.label8.TabIndex = 0;
            this.label8.Text = "Floor";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.pizzaSize);
            this.groupBox2.Controls.Add(this.numPizzaId);
            this.groupBox2.Controls.Add(this.pizzaType);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(26, 361);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(225, 128);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pizza";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(20, 16);
            this.label11.TabIndex = 13;
            this.label11.Text = "ID";
            // 
            // pizzaSize
            // 
            this.pizzaSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pizzaSize.FormattingEnabled = true;
            this.pizzaSize.Items.AddRange(new object[] {
            "Small - 28cm",
            "Medium - 32cm",
            "Large - 40cm"});
            this.pizzaSize.Location = new System.Drawing.Point(56, 84);
            this.pizzaSize.Name = "pizzaSize";
            this.pizzaSize.Size = new System.Drawing.Size(156, 24);
            this.pizzaSize.TabIndex = 3;
            // 
            // numPizzaId
            // 
            this.numPizzaId.Location = new System.Drawing.Point(55, 25);
            this.numPizzaId.Name = "numPizzaId";
            this.numPizzaId.Size = new System.Drawing.Size(133, 22);
            this.numPizzaId.TabIndex = 12;
            this.numPizzaId.Validating += new System.ComponentModel.CancelEventHandler(this.numPizzaId_Validating);
            this.numPizzaId.Validated += new System.EventHandler(this.numPizzaId_Validated);
            // 
            // pizzaType
            // 
            this.pizzaType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pizzaType.FormattingEnabled = true;
            this.pizzaType.Items.AddRange(new object[] {
            "Margherita",
            "Quattro Formaggi",
            "Quattro Stagioni",
            "Pepperoni",
            "Diavola"});
            this.pizzaType.Location = new System.Drawing.Point(56, 54);
            this.pizzaType.Name = "pizzaType";
            this.pizzaType.Size = new System.Drawing.Size(156, 24);
            this.pizzaType.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 89);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 16);
            this.label9.TabIndex = 1;
            this.label9.Text = "Size";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Type";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(102, 495);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(70, 30);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // AddEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(285, 534);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox1);
            this.Name = "AddEditForm";
            this.ShowIcon = false;
            this.Text = "Add or Edit client";
            this.Load += new System.EventHandler(this.EditForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddEditForm_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numClientId)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAddressId)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPizzaId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox phoneNo;
        private System.Windows.Forms.TextBox firstName;
        private System.Windows.Forms.TextBox lastName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox apartment;
        private System.Windows.Forms.TextBox floor;
        private System.Windows.Forms.TextBox street;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox pizzaSize;
        private System.Windows.Forms.ComboBox pizzaType;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numClientId;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numAddressId;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numPizzaId;
    }
}