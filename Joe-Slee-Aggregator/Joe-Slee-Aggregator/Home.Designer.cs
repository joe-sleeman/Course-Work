namespace Joe_Slee_Aggregator
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.rtArticles = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.btnRandom = new System.Windows.Forms.Button();
            this.cbSearchType = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnNextTen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.picboxSpinner = new System.Windows.Forms.PictureBox();
            this.picboxTick = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnRemoveLikes = new System.Windows.Forms.Button();
            this.checkedListLikes = new System.Windows.Forms.CheckedListBox();
            this.btnRemoveDislikes = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkedListDislikes = new System.Windows.Forms.CheckedListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnDislike = new System.Windows.Forms.Button();
            this.btnLike = new System.Windows.Forms.Button();
            this.checkedListAllTopics = new System.Windows.Forms.CheckedListBox();
            this.btnNewTopic = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNewTopic = new System.Windows.Forms.TextBox();
            this.lblCurrTopic = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxTick)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtArticles
            // 
            this.rtArticles.Location = new System.Drawing.Point(0, 19);
            this.rtArticles.Name = "rtArticles";
            this.rtArticles.Size = new System.Drawing.Size(639, 818);
            this.rtArticles.TabIndex = 0;
            this.rtArticles.Text = "";
            this.rtArticles.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtArticles_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtArticles);
            this.groupBox1.Location = new System.Drawing.Point(336, 163);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(655, 837);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Article Viewer";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.webBrowser1);
            this.groupBox2.Location = new System.Drawing.Point(1009, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(873, 991);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Web Browser";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(3, 16);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(867, 972);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // btnRandom
            // 
            this.btnRandom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRandom.Location = new System.Drawing.Point(304, 24);
            this.btnRandom.Name = "btnRandom";
            this.btnRandom.Size = new System.Drawing.Size(133, 28);
            this.btnRandom.TabIndex = 3;
            this.btnRandom.Text = "Random Topic";
            this.btnRandom.UseVisualStyleBackColor = true;
            this.btnRandom.Click += new System.EventHandler(this.btnRandom_Click);
            // 
            // cbSearchType
            // 
            this.cbSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSearchType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSearchType.FormattingEnabled = true;
            this.cbSearchType.Location = new System.Drawing.Point(122, 24);
            this.cbSearchType.Name = "cbSearchType";
            this.cbSearchType.Size = new System.Drawing.Size(164, 28);
            this.cbSearchType.TabIndex = 4;
            // 
            // btnNextTen
            // 
            this.btnNextTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextTen.Location = new System.Drawing.Point(454, 24);
            this.btnNextTen.Name = "btnNextTen";
            this.btnNextTen.Size = new System.Drawing.Size(133, 28);
            this.btnNextTen.TabIndex = 6;
            this.btnNextTen.Text = "Next 10 Articles";
            this.btnNextTen.UseVisualStyleBackColor = true;
            this.btnNextTen.Click += new System.EventHandler(this.btnNextTen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "Article Type:";
            // 
            // picboxSpinner
            // 
            this.picboxSpinner.Image = ((System.Drawing.Image)(resources.GetObject("picboxSpinner.Image")));
            this.picboxSpinner.Location = new System.Drawing.Point(904, 69);
            this.picboxSpinner.Name = "picboxSpinner";
            this.picboxSpinner.Size = new System.Drawing.Size(71, 65);
            this.picboxSpinner.TabIndex = 8;
            this.picboxSpinner.TabStop = false;
            // 
            // picboxTick
            // 
            this.picboxTick.Image = ((System.Drawing.Image)(resources.GetObject("picboxTick.Image")));
            this.picboxTick.Location = new System.Drawing.Point(904, 74);
            this.picboxTick.Name = "picboxTick";
            this.picboxTick.Size = new System.Drawing.Size(71, 65);
            this.picboxTick.TabIndex = 9;
            this.picboxTick.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnRemoveLikes);
            this.groupBox3.Controls.Add(this.checkedListLikes);
            this.groupBox3.Location = new System.Drawing.Point(28, 85);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(289, 233);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Likes";
            // 
            // btnRemoveLikes
            // 
            this.btnRemoveLikes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveLikes.Location = new System.Drawing.Point(52, 179);
            this.btnRemoveLikes.Name = "btnRemoveLikes";
            this.btnRemoveLikes.Size = new System.Drawing.Size(171, 39);
            this.btnRemoveLikes.TabIndex = 1;
            this.btnRemoveLikes.Text = "Remove Selected";
            this.btnRemoveLikes.UseVisualStyleBackColor = true;
            this.btnRemoveLikes.Click += new System.EventHandler(this.btnRemoveLikes_Click);
            // 
            // checkedListLikes
            // 
            this.checkedListLikes.CheckOnClick = true;
            this.checkedListLikes.FormattingEnabled = true;
            this.checkedListLikes.Location = new System.Drawing.Point(7, 19);
            this.checkedListLikes.Name = "checkedListLikes";
            this.checkedListLikes.Size = new System.Drawing.Size(276, 154);
            this.checkedListLikes.TabIndex = 0;
            // 
            // btnRemoveDislikes
            // 
            this.btnRemoveDislikes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveDislikes.Location = new System.Drawing.Point(54, 179);
            this.btnRemoveDislikes.Name = "btnRemoveDislikes";
            this.btnRemoveDislikes.Size = new System.Drawing.Size(171, 39);
            this.btnRemoveDislikes.TabIndex = 1;
            this.btnRemoveDislikes.Text = "Remove Selected";
            this.btnRemoveDislikes.UseVisualStyleBackColor = true;
            this.btnRemoveDislikes.Click += new System.EventHandler(this.btnRemoveDislikes_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnRemoveDislikes);
            this.groupBox4.Controls.Add(this.checkedListDislikes);
            this.groupBox4.Location = new System.Drawing.Point(28, 324);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(289, 233);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Dislikes";
            // 
            // checkedListDislikes
            // 
            this.checkedListDislikes.CheckOnClick = true;
            this.checkedListDislikes.FormattingEnabled = true;
            this.checkedListDislikes.Location = new System.Drawing.Point(7, 19);
            this.checkedListDislikes.Name = "checkedListDislikes";
            this.checkedListDislikes.Size = new System.Drawing.Size(276, 154);
            this.checkedListDislikes.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnDislike);
            this.groupBox5.Controls.Add(this.btnLike);
            this.groupBox5.Controls.Add(this.checkedListAllTopics);
            this.groupBox5.Location = new System.Drawing.Point(28, 563);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(289, 233);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Other Topics";
            // 
            // btnDislike
            // 
            this.btnDislike.Location = new System.Drawing.Point(149, 179);
            this.btnDislike.Name = "btnDislike";
            this.btnDislike.Size = new System.Drawing.Size(134, 33);
            this.btnDislike.TabIndex = 2;
            this.btnDislike.Text = "Dislike Selected";
            this.btnDislike.UseVisualStyleBackColor = true;
            this.btnDislike.Click += new System.EventHandler(this.btnDislike_Click);
            // 
            // btnLike
            // 
            this.btnLike.Location = new System.Drawing.Point(7, 179);
            this.btnLike.Name = "btnLike";
            this.btnLike.Size = new System.Drawing.Size(127, 33);
            this.btnLike.TabIndex = 1;
            this.btnLike.Text = "Like Selected";
            this.btnLike.UseVisualStyleBackColor = true;
            this.btnLike.Click += new System.EventHandler(this.btnLike_Click);
            // 
            // checkedListAllTopics
            // 
            this.checkedListAllTopics.CheckOnClick = true;
            this.checkedListAllTopics.FormattingEnabled = true;
            this.checkedListAllTopics.Location = new System.Drawing.Point(7, 19);
            this.checkedListAllTopics.Name = "checkedListAllTopics";
            this.checkedListAllTopics.Size = new System.Drawing.Size(276, 154);
            this.checkedListAllTopics.TabIndex = 0;
            // 
            // btnNewTopic
            // 
            this.btnNewTopic.Location = new System.Drawing.Point(42, 64);
            this.btnNewTopic.Name = "btnNewTopic";
            this.btnNewTopic.Size = new System.Drawing.Size(171, 38);
            this.btnNewTopic.TabIndex = 12;
            this.btnNewTopic.Text = "Add Topic";
            this.btnNewTopic.UseVisualStyleBackColor = true;
            this.btnNewTopic.Click += new System.EventHandler(this.btnNewTopic_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.btnNewTopic);
            this.groupBox6.Controls.Add(this.txtNewTopic);
            this.groupBox6.Location = new System.Drawing.Point(35, 821);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(282, 121);
            this.groupBox6.TabIndex = 13;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "New Topic";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "New Topic:";
            // 
            // txtNewTopic
            // 
            this.txtNewTopic.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewTopic.Location = new System.Drawing.Point(119, 20);
            this.txtNewTopic.Name = "txtNewTopic";
            this.txtNewTopic.Size = new System.Drawing.Size(157, 29);
            this.txtNewTopic.TabIndex = 0;
            // 
            // lblCurrTopic
            // 
            this.lblCurrTopic.AutoSize = true;
            this.lblCurrTopic.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrTopic.Location = new System.Drawing.Point(566, 115);
            this.lblCurrTopic.Name = "lblCurrTopic";
            this.lblCurrTopic.Size = new System.Drawing.Size(0, 24);
            this.lblCurrTopic.TabIndex = 14;
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(29, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(133, 35);
            this.btnLogout.TabIndex = 15;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(332, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(216, 24);
            this.label3.TabIndex = 16;
            this.label3.Text = "Currently Viewing Topic:";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label1);
            this.groupBox7.Controls.Add(this.cbSearchType);
            this.groupBox7.Controls.Add(this.btnRandom);
            this.groupBox7.Controls.Add(this.btnNextTen);
            this.groupBox7.Location = new System.Drawing.Point(235, 9);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(663, 70);
            this.groupBox7.TabIndex = 1;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "groupBox7";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1042);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lblCurrTopic);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.picboxTick);
            this.Controls.Add(this.picboxSpinner);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picboxSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxTick)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtArticles;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button btnRandom;
        private System.Windows.Forms.ComboBox cbSearchType;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnNextTen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picboxSpinner;
        private System.Windows.Forms.PictureBox picboxTick;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnRemoveLikes;
        private System.Windows.Forms.CheckedListBox checkedListLikes;
        private System.Windows.Forms.Button btnRemoveDislikes;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckedListBox checkedListDislikes;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckedListBox checkedListAllTopics;
        private System.Windows.Forms.Button btnNewTopic;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNewTopic;
        private System.Windows.Forms.Button btnDislike;
        private System.Windows.Forms.Button btnLike;
        private System.Windows.Forms.Label lblCurrTopic;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox7;
    }
}

