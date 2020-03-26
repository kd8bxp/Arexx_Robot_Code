<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TextBox_Log_APC = New System.Windows.Forms.TextBox()
        Me.Button_Default = New System.Windows.Forms.Button()
        Me.Button_Read = New System.Windows.Forms.Button()
        Me.Button_Write = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ComBox_Series_Patity = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ComBox_Series_Rate = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComBox_RF_Power = New System.Windows.Forms.ComboBox()
        Me.TextBox_Freq = New System.Windows.Forms.TextBox()
        Me.ComBox_TRxRate = New System.Windows.Forms.ComboBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Timer_Settings_RW = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBox_Log_APC
        '
        Me.TextBox_Log_APC.BackColor = System.Drawing.SystemColors.Menu
        Me.TextBox_Log_APC.ForeColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(1, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.TextBox_Log_APC.Location = New System.Drawing.Point(13, 212)
        Me.TextBox_Log_APC.Multiline = True
        Me.TextBox_Log_APC.Name = "TextBox_Log_APC"
        Me.TextBox_Log_APC.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox_Log_APC.Size = New System.Drawing.Size(415, 79)
        Me.TextBox_Log_APC.TabIndex = 15
        '
        'Button_Default
        '
        Me.Button_Default.BackColor = System.Drawing.Color.SteelBlue
        Me.Button_Default.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Default.ForeColor = System.Drawing.Color.White
        Me.Button_Default.Location = New System.Drawing.Point(192, 170)
        Me.Button_Default.Name = "Button_Default"
        Me.Button_Default.Size = New System.Drawing.Size(75, 23)
        Me.Button_Default.TabIndex = 14
        Me.Button_Default.Text = "Default"
        Me.Button_Default.UseVisualStyleBackColor = False
        '
        'Button_Read
        '
        Me.Button_Read.BackColor = System.Drawing.Color.SteelBlue
        Me.Button_Read.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Read.ForeColor = System.Drawing.Color.White
        Me.Button_Read.Location = New System.Drawing.Point(102, 170)
        Me.Button_Read.Name = "Button_Read"
        Me.Button_Read.Size = New System.Drawing.Size(75, 23)
        Me.Button_Read.TabIndex = 13
        Me.Button_Read.Text = "Read"
        Me.Button_Read.UseVisualStyleBackColor = False
        '
        'Button_Write
        '
        Me.Button_Write.BackColor = System.Drawing.Color.SteelBlue
        Me.Button_Write.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Write.ForeColor = System.Drawing.Color.White
        Me.Button_Write.Location = New System.Drawing.Point(12, 170)
        Me.Button_Write.Name = "Button_Write"
        Me.Button_Write.Size = New System.Drawing.Size(75, 23)
        Me.Button_Write.TabIndex = 12
        Me.Button_Write.Text = "Write"
        Me.Button_Write.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.ComBox_Series_Patity)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.ComBox_Series_Rate)
        Me.GroupBox3.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(1, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.GroupBox3.Location = New System.Drawing.Point(227, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(202, 143)
        Me.GroupBox3.TabIndex = 11
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Series Parameters"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(162, 31)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(26, 14)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "bps"
        '
        'ComBox_Series_Patity
        '
        Me.ComBox_Series_Patity.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComBox_Series_Patity.ForeColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(1, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.ComBox_Series_Patity.FormattingEnabled = True
        Me.ComBox_Series_Patity.Items.AddRange(New Object() {"Disable", "Even parity", "Odd parity"})
        Me.ComBox_Series_Patity.Location = New System.Drawing.Point(91, 60)
        Me.ComBox_Series_Patity.Name = "ComBox_Series_Patity"
        Me.ComBox_Series_Patity.Size = New System.Drawing.Size(81, 22)
        Me.ComBox_Series_Patity.TabIndex = 3
        Me.ComBox_Series_Patity.Text = "Disable"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(8, 63)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(74, 14)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Series Patity"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(8, 31)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 14)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Series rate"
        '
        'ComBox_Series_Rate
        '
        Me.ComBox_Series_Rate.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComBox_Series_Rate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(1, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.ComBox_Series_Rate.FormattingEnabled = True
        Me.ComBox_Series_Rate.Items.AddRange(New Object() {"1200", "2400", "4800", "9600", "19200", "38400", "57600"})
        Me.ComBox_Series_Rate.Location = New System.Drawing.Point(91, 28)
        Me.ComBox_Series_Rate.Name = "ComBox_Series_Rate"
        Me.ComBox_Series_Rate.Size = New System.Drawing.Size(71, 22)
        Me.ComBox_Series_Rate.TabIndex = 3
        Me.ComBox_Series_Rate.Text = "9600"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.ComBox_RF_Power)
        Me.GroupBox1.Controls.Add(Me.TextBox_Freq)
        Me.GroupBox1.Controls.Add(Me.ComBox_TRxRate)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(1, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(209, 143)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "RF parameters"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(7, 33)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 14)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "RF Frequency"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(167, 69)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(26, 14)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "bps"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(165, 33)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 14)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "MHz"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 106)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 14)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "RF Power"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 14)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "RF TRx rate"
        '
        'ComBox_RF_Power
        '
        Me.ComBox_RF_Power.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComBox_RF_Power.ForeColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(1, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.ComBox_RF_Power.FormattingEnabled = True
        Me.ComBox_RF_Power.Items.AddRange(New Object() {"0 (MIN)", "1", "2", "3", "4", "5", "6", "7", "8", "9 (MAX)"})
        Me.ComBox_RF_Power.Location = New System.Drawing.Point(95, 103)
        Me.ComBox_RF_Power.Name = "ComBox_RF_Power"
        Me.ComBox_RF_Power.Size = New System.Drawing.Size(70, 22)
        Me.ComBox_RF_Power.TabIndex = 9
        Me.ComBox_RF_Power.Text = "5"
        '
        'TextBox_Freq
        '
        Me.TextBox_Freq.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox_Freq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(1, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.TextBox_Freq.Location = New System.Drawing.Point(95, 30)
        Me.TextBox_Freq.MaxLength = 7
        Me.TextBox_Freq.Name = "TextBox_Freq"
        Me.TextBox_Freq.Size = New System.Drawing.Size(64, 22)
        Me.TextBox_Freq.TabIndex = 2
        Me.TextBox_Freq.Text = "433,000"
        '
        'ComBox_TRxRate
        '
        Me.ComBox_TRxRate.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComBox_TRxRate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(1, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.ComBox_TRxRate.FormattingEnabled = True
        Me.ComBox_TRxRate.Items.AddRange(New Object() {"2400", "4800", "9600", "19200"})
        Me.ComBox_TRxRate.Location = New System.Drawing.Point(95, 66)
        Me.ComBox_TRxRate.Name = "ComBox_TRxRate"
        Me.ComBox_TRxRate.Size = New System.Drawing.Size(70, 22)
        Me.ComBox_TRxRate.TabIndex = 4
        Me.ComBox_TRxRate.Text = "9600"
        '
        'Timer_Settings_RW
        '
        Me.Timer_Settings_RW.Interval = 1200
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(440, 313)
        Me.Controls.Add(Me.TextBox_Log_APC)
        Me.Controls.Add(Me.Button_Default)
        Me.Controls.Add(Me.Button_Read)
        Me.Controls.Add(Me.Button_Write)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Settings"
        Me.Text = "Settings"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox_Log_APC As System.Windows.Forms.TextBox
    Friend WithEvents Button_Default As System.Windows.Forms.Button
    Friend WithEvents Button_Read As System.Windows.Forms.Button
    Friend WithEvents Button_Write As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ComBox_Series_Patity As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ComBox_Series_Rate As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComBox_RF_Power As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox_Freq As System.Windows.Forms.TextBox
    Friend WithEvents ComBox_TRxRate As System.Windows.Forms.ComboBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents Timer_Settings_RW As System.Windows.Forms.Timer
End Class
