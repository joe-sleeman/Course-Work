namespace GreyScott
{
    partial class Form1
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
            this.txtFeedA = new System.Windows.Forms.TextBox();
            this.txtKillB = new System.Windows.Forms.TextBox();
            this.btnBegin = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblCount = new System.Windows.Forms.Label();
            this.btnSkipOneThousand = new System.Windows.Forms.Button();
            this.btnFiveThousand = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTick = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSaveImage = new System.Windows.Forms.Button();
            this.cbLaplacian = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbColourScheme = new System.Windows.Forms.ComboBox();
            this.btnRunBatch = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cbBatchColourScheme = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbBatchLaplacian = new System.Windows.Forms.ComboBox();
            this.txtStartB = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEndB = new System.Windows.Forms.TextBox();
            this.txtEndA = new System.Windows.Forms.TextBox();
            this.txtStartA = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFeedA
            // 
            this.txtFeedA.Location = new System.Drawing.Point(68, 19);
            this.txtFeedA.Name = "txtFeedA";
            this.txtFeedA.Size = new System.Drawing.Size(52, 20);
            this.txtFeedA.TabIndex = 0;
            this.txtFeedA.Text = "0.025";
            // 
            // txtKillB
            // 
            this.txtKillB.Location = new System.Drawing.Point(184, 19);
            this.txtKillB.Name = "txtKillB";
            this.txtKillB.Size = new System.Drawing.Size(52, 20);
            this.txtKillB.TabIndex = 1;
            this.txtKillB.Text = "0.056";
            // 
            // btnBegin
            // 
            this.btnBegin.BackColor = System.Drawing.Color.YellowGreen;
            this.btnBegin.Location = new System.Drawing.Point(297, 18);
            this.btnBegin.Name = "btnBegin";
            this.btnBegin.Size = new System.Drawing.Size(82, 23);
            this.btnBegin.TabIndex = 2;
            this.btnBegin.Text = "Start / Stop";
            this.btnBegin.UseVisualStyleBackColor = false;
            this.btnBegin.Click += new System.EventHandler(this.btnBegin_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.Location = new System.Drawing.Point(368, 494);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(0, 16);
            this.lblCount.TabIndex = 3;
            // 
            // btnSkipOneThousand
            // 
            this.btnSkipOneThousand.Location = new System.Drawing.Point(209, 47);
            this.btnSkipOneThousand.Name = "btnSkipOneThousand";
            this.btnSkipOneThousand.Size = new System.Drawing.Size(82, 23);
            this.btnSkipOneThousand.TabIndex = 5;
            this.btnSkipOneThousand.Text = "Skip 1000";
            this.btnSkipOneThousand.UseVisualStyleBackColor = true;
            this.btnSkipOneThousand.Click += new System.EventHandler(this.btnSkipOneThousand_Click);
            // 
            // btnFiveThousand
            // 
            this.btnFiveThousand.Location = new System.Drawing.Point(209, 75);
            this.btnFiveThousand.Name = "btnFiveThousand";
            this.btnFiveThousand.Size = new System.Drawing.Size(82, 23);
            this.btnFiveThousand.TabIndex = 6;
            this.btnFiveThousand.Text = "Skip 5000";
            this.btnFiveThousand.UseVisualStyleBackColor = true;
            this.btnFiveThousand.Click += new System.EventHandler(this.btnFiveThousand_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblTick);
            this.groupBox2.Controls.Add(this.btnReset);
            this.groupBox2.Controls.Add(this.btnBegin);
            this.groupBox2.Controls.Add(this.btnFiveThousand);
            this.groupBox2.Controls.Add(this.btnSkipOneThousand);
            this.groupBox2.Controls.Add(this.btnSaveImage);
            this.groupBox2.Controls.Add(this.txtFeedA);
            this.groupBox2.Controls.Add(this.txtKillB);
            this.groupBox2.Controls.Add(this.cbLaplacian);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cbColourScheme);
            this.groupBox2.Location = new System.Drawing.Point(3, 421);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(390, 107);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Run Single";
            // 
            // lblTick
            // 
            this.lblTick.AutoSize = true;
            this.lblTick.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTick.Location = new System.Drawing.Point(243, 20);
            this.lblTick.Name = "lblTick";
            this.lblTick.Size = new System.Drawing.Size(15, 16);
            this.lblTick.TabIndex = 13;
            this.lblTick.Text = "0";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(297, 47);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(82, 23);
            this.btnReset.TabIndex = 12;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.Location = new System.Drawing.Point(297, 75);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(82, 23);
            this.btnSaveImage.TabIndex = 10;
            this.btnSaveImage.Text = "Save Image";
            this.btnSaveImage.UseVisualStyleBackColor = true;
            this.btnSaveImage.Click += new System.EventHandler(this.btnSaveImage_Click);
            // 
            // cbLaplacian
            // 
            this.cbLaplacian.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLaplacian.FormattingEnabled = true;
            this.cbLaplacian.Location = new System.Drawing.Point(105, 47);
            this.cbLaplacian.Name = "cbLaplacian";
            this.cbLaplacian.Size = new System.Drawing.Size(98, 21);
            this.cbLaplacian.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(2, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Laplacian:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Feed A:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(138, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Kill B:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Colour Scheme:";
            // 
            // cbColourScheme
            // 
            this.cbColourScheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColourScheme.FormattingEnabled = true;
            this.cbColourScheme.Location = new System.Drawing.Point(105, 75);
            this.cbColourScheme.Name = "cbColourScheme";
            this.cbColourScheme.Size = new System.Drawing.Size(98, 21);
            this.cbColourScheme.TabIndex = 9;
            // 
            // btnRunBatch
            // 
            this.btnRunBatch.Location = new System.Drawing.Point(313, 17);
            this.btnRunBatch.Name = "btnRunBatch";
            this.btnRunBatch.Size = new System.Drawing.Size(71, 23);
            this.btnRunBatch.TabIndex = 7;
            this.btnRunBatch.Text = "Run Batch";
            this.btnRunBatch.UseVisualStyleBackColor = true;
            this.btnRunBatch.Click += new System.EventHandler(this.btnRunBatch_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnHelp);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cbBatchColourScheme);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cbBatchLaplacian);
            this.groupBox1.Controls.Add(this.txtStartB);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtEndB);
            this.groupBox1.Controls.Add(this.txtEndA);
            this.groupBox1.Controls.Add(this.btnRunBatch);
            this.groupBox1.Controls.Add(this.txtStartA);
            this.groupBox1.Location = new System.Drawing.Point(3, 529);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(390, 102);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Run Batch";
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(313, 45);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(71, 23);
            this.btnHelp.TabIndex = 10;
            this.btnHelp.Text = "HELP";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 16);
            this.label9.TabIndex = 12;
            this.label9.Text = "Laplacian:";
            // 
            // cbBatchColourScheme
            // 
            this.cbBatchColourScheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBatchColourScheme.FormattingEnabled = true;
            this.cbBatchColourScheme.Location = new System.Drawing.Point(283, 73);
            this.cbBatchColourScheme.Name = "cbBatchColourScheme";
            this.cbBatchColourScheme.Size = new System.Drawing.Size(101, 21);
            this.cbBatchColourScheme.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(181, 75);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 16);
            this.label10.TabIndex = 13;
            this.label10.Text = "Colour Scheme:";
            // 
            // cbBatchLaplacian
            // 
            this.cbBatchLaplacian.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBatchLaplacian.FormattingEnabled = true;
            this.cbBatchLaplacian.Location = new System.Drawing.Point(82, 73);
            this.cbBatchLaplacian.Name = "cbBatchLaplacian";
            this.cbBatchLaplacian.Size = new System.Drawing.Size(96, 21);
            this.cbBatchLaplacian.TabIndex = 12;
            // 
            // txtStartB
            // 
            this.txtStartB.Location = new System.Drawing.Point(105, 45);
            this.txtStartB.Name = "txtStartB";
            this.txtStartB.Size = new System.Drawing.Size(52, 20);
            this.txtStartB.TabIndex = 10;
            this.txtStartB.Text = "0.056";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "Kill B (Start):";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(163, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 16);
            this.label8.TabIndex = 15;
            this.label8.Text = "Kill B (End):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(159, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Feed A (End):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Feed A (Start):";
            // 
            // txtEndB
            // 
            this.txtEndB.Location = new System.Drawing.Point(255, 45);
            this.txtEndB.Name = "txtEndB";
            this.txtEndB.Size = new System.Drawing.Size(52, 20);
            this.txtEndB.TabIndex = 11;
            this.txtEndB.Text = "0.080";
            // 
            // txtEndA
            // 
            this.txtEndA.Location = new System.Drawing.Point(255, 19);
            this.txtEndA.Name = "txtEndA";
            this.txtEndA.Size = new System.Drawing.Size(52, 20);
            this.txtEndA.TabIndex = 1;
            this.txtEndA.Text = "0.027";
            // 
            // txtStartA
            // 
            this.txtStartA.Location = new System.Drawing.Point(105, 19);
            this.txtStartA.Name = "txtStartA";
            this.txtStartA.Size = new System.Drawing.Size(52, 20);
            this.txtStartA.TabIndex = 0;
            this.txtStartA.Text = "0.025";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 636);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblCount);
            this.Name = "Form1";
            this.Text = "Grey Scott Simulation";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFeedA;
        private System.Windows.Forms.TextBox txtKillB;
        private System.Windows.Forms.Button btnBegin;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Button btnSkipOneThousand;
        private System.Windows.Forms.Button btnFiveThousand;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRunBatch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbLaplacian;
        private System.Windows.Forms.ComboBox cbColourScheme;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtEndB;
        private System.Windows.Forms.TextBox txtEndA;
        private System.Windows.Forms.TextBox txtStartB;
        private System.Windows.Forms.TextBox txtStartA;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbBatchColourScheme;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbBatchLaplacian;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSaveImage;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblTick;
        private System.Windows.Forms.Button btnHelp;

    }
}

