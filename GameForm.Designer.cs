namespace TetrisGame
{
    partial class GameForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.gamePBox = new System.Windows.Forms.PictureBox();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextPBox = new System.Windows.Forms.PictureBox();
            this.statGBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.gamePBox)).BeginInit();
            this.mainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nextPBox)).BeginInit();
            this.SuspendLayout();
            // 
            // gamePBox
            // 
            this.gamePBox.BackColor = System.Drawing.Color.White;
            this.gamePBox.Location = new System.Drawing.Point(24, 57);
            this.gamePBox.Name = "gamePBox";
            this.gamePBox.Size = new System.Drawing.Size(300, 600);
            this.gamePBox.TabIndex = 0;
            this.gamePBox.TabStop = false;
            this.gamePBox.Paint += new System.Windows.Forms.PaintEventHandler(this.gamePBox_Paint);
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(582, 28);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "Главное меню";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.pauseToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.gameToolStripMenuItem.Text = "Игра";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(158, 24);
            this.newGameToolStripMenuItem.Text = "Новая игра";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(158, 24);
            this.pauseToolStripMenuItem.Text = "Пауза";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(158, 24);
            this.exitToolStripMenuItem.Text = "Выход";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.helpToolStripMenuItem.Text = "Помощь";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.aboutToolStripMenuItem.Text = "Об игре";
            // 
            // nextPBox
            // 
            this.nextPBox.Location = new System.Drawing.Point(409, 57);
            this.nextPBox.Name = "nextPBox";
            this.nextPBox.Size = new System.Drawing.Size(100, 100);
            this.nextPBox.TabIndex = 2;
            this.nextPBox.TabStop = false;
            // 
            // statGBox
            // 
            this.statGBox.Location = new System.Drawing.Point(350, 239);
            this.statGBox.Name = "statGBox";
            this.statGBox.Size = new System.Drawing.Size(200, 179);
            this.statGBox.TabIndex = 3;
            this.statGBox.TabStop = false;
            this.statGBox.Text = "Статистика";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 703);
            this.Controls.Add(this.statGBox);
            this.Controls.Add(this.nextPBox);
            this.Controls.Add(this.gamePBox);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "GameForm";
            this.Text = "Добрая игра";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameForm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GameForm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.gamePBox)).EndInit();
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nextPBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox gamePBox;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.PictureBox nextPBox;
        private System.Windows.Forms.GroupBox statGBox;
    }
}

