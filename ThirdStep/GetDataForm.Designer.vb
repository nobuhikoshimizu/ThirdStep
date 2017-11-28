<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class getData
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(getData))
        Me.AxJVLink1 = New AxJVDTLabLib.AxJVLink()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.menuConfig = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuConfigJV = New System.Windows.Forms.ToolStripMenuItem()
        Me.getDataBtn = New System.Windows.Forms.Button()
        Me.prgJVRead = New System.Windows.Forms.ProgressBar()
        Me.TimerDownload = New System.Windows.Forms.Timer(Me.components)
        Me.getDiffBtn = New System.Windows.Forms.Button()
        Me.getSokuhouBtn = New System.Windows.Forms.Button()
        CType(Me.AxJVLink1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'AxJVLink1
        '
        Me.AxJVLink1.Enabled = True
        Me.AxJVLink1.Location = New System.Drawing.Point(164, 334)
        Me.AxJVLink1.Name = "AxJVLink1"
        Me.AxJVLink1.OcxState = CType(resources.GetObject("AxJVLink1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxJVLink1.Size = New System.Drawing.Size(288, 288)
        Me.AxJVLink1.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuConfig})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1377, 33)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'menuConfig
        '
        Me.menuConfig.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuConfigJV})
        Me.menuConfig.Name = "menuConfig"
        Me.menuConfig.Size = New System.Drawing.Size(81, 29)
        Me.menuConfig.Text = "設定(&C)"
        '
        'menuConfigJV
        '
        Me.menuConfigJV.Name = "menuConfigJV"
        Me.menuConfigJV.Size = New System.Drawing.Size(234, 30)
        Me.menuConfigJV.Text = "JV-Link の設定(&J)..."
        '
        'getDataBtn
        '
        Me.getDataBtn.Location = New System.Drawing.Point(30, 59)
        Me.getDataBtn.Name = "getDataBtn"
        Me.getDataBtn.Size = New System.Drawing.Size(219, 57)
        Me.getDataBtn.TabIndex = 2
        Me.getDataBtn.Text = "レース情報"
        Me.getDataBtn.UseVisualStyleBackColor = True
        '
        'prgJVRead
        '
        Me.prgJVRead.Location = New System.Drawing.Point(30, 133)
        Me.prgJVRead.Name = "prgJVRead"
        Me.prgJVRead.Size = New System.Drawing.Size(1322, 22)
        Me.prgJVRead.TabIndex = 3
        '
        'getDiffBtn
        '
        Me.getDiffBtn.Location = New System.Drawing.Point(273, 59)
        Me.getDiffBtn.Name = "getDiffBtn"
        Me.getDiffBtn.Size = New System.Drawing.Size(219, 57)
        Me.getDiffBtn.TabIndex = 4
        Me.getDiffBtn.Text = "蓄積情報"
        Me.getDiffBtn.UseVisualStyleBackColor = True
        '
        'getSokuhouBtn
        '
        Me.getSokuhouBtn.Location = New System.Drawing.Point(513, 59)
        Me.getSokuhouBtn.Name = "getSokuhouBtn"
        Me.getSokuhouBtn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.getSokuhouBtn.Size = New System.Drawing.Size(219, 57)
        Me.getSokuhouBtn.TabIndex = 5
        Me.getSokuhouBtn.Text = "速報情報"
        Me.getSokuhouBtn.UseVisualStyleBackColor = True
        '
        'getData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1377, 185)
        Me.Controls.Add(Me.getSokuhouBtn)
        Me.Controls.Add(Me.getDiffBtn)
        Me.Controls.Add(Me.prgJVRead)
        Me.Controls.Add(Me.getDataBtn)
        Me.Controls.Add(Me.AxJVLink1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "getData"
        Me.Text = "データ取得"
        CType(Me.AxJVLink1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents AxJVLink1 As AxJVDTLabLib.AxJVLink
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents menuConfig As ToolStripMenuItem
    Friend WithEvents menuConfigJV As ToolStripMenuItem
    Friend WithEvents getDataBtn As Button
    Friend WithEvents prgJVRead As ProgressBar
    Friend WithEvents TimerDownload As Timer
    Friend WithEvents getDiffBtn As Button
    Friend WithEvents getSokuhouBtn As Button
End Class
