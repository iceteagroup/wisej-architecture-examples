﻿namespace Wisej.Architecture.MVVM
{
	partial class Page1
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

		#region Wisej Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.dataGridView1 = new Wisej.Web.DataGridView();
			this.button1 = new Wisej.Web.Button();
			this.label1 = new Wisej.Web.Label();
			this.txtId = new Wisej.Web.TextBox();
			this.txtEmail = new Wisej.Web.TextBox();
			this.txtName = new Wisej.Web.TextBox();
			this.txtAge = new Wisej.Web.TextBox();
			this.button2 = new Wisej.Web.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.Location = new System.Drawing.Point(102, 70);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(598, 276);
			this.dataGridView1.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(740, 298);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(146, 37);
			this.button1.TabIndex = 1;
			this.button1.Text = "Add Student";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(324, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(129, 18);
			this.label1.TabIndex = 2;
			this.label1.Text = "Student Management";
			// 
			// txtId
			// 
			this.txtId.InputType.Type = Wisej.Web.TextBoxType.Number;
			this.txtId.LabelText = "Id";
			this.txtId.Location = new System.Drawing.Point(740, 53);
			this.txtId.Name = "txtId";
			this.txtId.Size = new System.Drawing.Size(149, 53);
			this.txtId.TabIndex = 3;
			// 
			// txtEmail
			// 
			this.txtEmail.LabelText = "Email";
			this.txtEmail.Location = new System.Drawing.Point(740, 112);
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(146, 53);
			this.txtEmail.TabIndex = 4;
			// 
			// txtName
			// 
			this.txtName.LabelText = "Name";
			this.txtName.Location = new System.Drawing.Point(740, 171);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(146, 53);
			this.txtName.TabIndex = 5;
			// 
			// txtAge
			// 
			this.txtAge.InputType.Type = Wisej.Web.TextBoxType.Number;
			this.txtAge.LabelText = "Age";
			this.txtAge.Location = new System.Drawing.Point(740, 230);
			this.txtAge.Name = "txtAge";
			this.txtAge.Size = new System.Drawing.Size(149, 53);
			this.txtAge.TabIndex = 6;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(929, 70);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(146, 37);
			this.button2.TabIndex = 7;
			this.button2.Text = "Clear Fields";
			// 
			// Page1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
			this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
			this.Controls.Add(this.button2);
			this.Controls.Add(this.txtAge);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.txtEmail);
			this.Controls.Add(this.txtId);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.dataGridView1);
			this.Name = "Page1";
			this.Size = new System.Drawing.Size(2380, 981);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Wisej.Web.DataGridView dataGridView1;
		private Wisej.Web.Button button1;
		private Wisej.Web.Label label1;
		private Wisej.Web.TextBox txtId;
		private Wisej.Web.TextBox txtEmail;
		private Wisej.Web.TextBox txtName;
		private Wisej.Web.TextBox txtAge;
		private Web.Button button2;
	}
}


