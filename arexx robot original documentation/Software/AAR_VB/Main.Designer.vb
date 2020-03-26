<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Me.SerialPort_APC220 = New System.IO.Ports.SerialPort(Me.components)
        Me.Timer_ASK_Data = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_Connection_Check = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_WT_Timeout = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox_connection = New System.Windows.Forms.GroupBox()
        Me.Button_refresh_comport = New System.Windows.Forms.Button()
        Me.Button_Connect = New System.Windows.Forms.Button()
        Me.ComBox_Comports = New System.Windows.Forms.ComboBox()
        Me.GroupBox_BatteryVoltage = New System.Windows.Forms.GroupBox()
        Me.ProgressBar_Voltage = New System.Windows.Forms.ProgressBar()
        Me.Label_Battery_Voltage = New System.Windows.Forms.Label()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.Label_Connection_RP6 = New System.Windows.Forms.Label()
        Me.Label_Dongle_Status = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.Main1 = New System.Windows.Forms.TabPage()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ProgressBar_Speed_Right = New System.Windows.Forms.ProgressBar()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ProgressBar_Speed_Left = New System.Windows.Forms.ProgressBar()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.HScrollBar_Speed = New System.Windows.Forms.HScrollBar()
        Me.Button_Backward = New System.Windows.Forms.Button()
        Me.Button_Right = New System.Windows.Forms.Button()
        Me.Button_Forward = New System.Windows.Forms.Button()
        Me.Button_Left = New System.Windows.Forms.Button()
        Me.Button_Stop = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LineCheck = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ProgressBar_Current_Left = New System.Windows.Forms.ProgressBar()
        Me.ProgressBar_Current_Right = New System.Windows.Forms.ProgressBar()
        Me.Settings1 = New System.Windows.Forms.TabPage()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.GroupBox_Settings = New System.Windows.Forms.GroupBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Panel_Settings = New System.Windows.Forms.Panel()
        Me.Status = New System.Windows.Forms.TabPage()
        Me.Button_Test_Communication = New System.Windows.Forms.Button()
        Me.TextBox_Test_Status = New System.Windows.Forms.TextBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label_start_time_application = New System.Windows.Forms.Label()
        Me.Label_Time_Connected = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label_transmitted_packets = New System.Windows.Forms.Label()
        Me.Label_received_packets = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label_Wrong_Packets = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label_Wrong_Packets_RP6 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Timer_RF_Test = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox_connection.SuspendLayout()
        Me.GroupBox_BatteryVoltage.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.Main1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Settings1.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox_Settings.SuspendLayout()
        Me.Status.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'SerialPort_APC220
        '
        Me.SerialPort_APC220.PortName = "COM7"
        Me.SerialPort_APC220.ReadBufferSize = 256
        '
        'Timer_ASK_Data
        '
        Me.Timer_ASK_Data.Interval = 1000
        '
        'Timer_Connection_Check
        '
        Me.Timer_Connection_Check.Enabled = True
        '
        'Timer_WT_Timeout
        '
        Me.Timer_WT_Timeout.Enabled = True
        Me.Timer_WT_Timeout.Interval = 1100
        '
        'GroupBox_connection
        '
        Me.GroupBox_connection.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_connection.Controls.Add(Me.Button_refresh_comport)
        Me.GroupBox_connection.Controls.Add(Me.Button_Connect)
        Me.GroupBox_connection.Controls.Add(Me.ComBox_Comports)
        Me.GroupBox_connection.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_connection.ForeColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(1, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.GroupBox_connection.Location = New System.Drawing.Point(22, 27)
        Me.GroupBox_connection.Name = "GroupBox_connection"
        Me.GroupBox_connection.Size = New System.Drawing.Size(364, 74)
        Me.GroupBox_connection.TabIndex = 8
        Me.GroupBox_connection.TabStop = False
        Me.GroupBox_connection.Text = "Connection"
        '
        'Button_refresh_comport
        '
        Me.Button_refresh_comport.BackColor = System.Drawing.Color.SteelBlue
        Me.Button_refresh_comport.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_refresh_comport.ForeColor = System.Drawing.Color.White
        Me.Button_refresh_comport.Location = New System.Drawing.Point(148, 31)
        Me.Button_refresh_comport.Name = "Button_refresh_comport"
        Me.Button_refresh_comport.Size = New System.Drawing.Size(75, 23)
        Me.Button_refresh_comport.TabIndex = 5
        Me.Button_refresh_comport.Text = "Refresh"
        Me.Button_refresh_comport.UseVisualStyleBackColor = False
        '
        'Button_Connect
        '
        Me.Button_Connect.BackColor = System.Drawing.Color.SteelBlue
        Me.Button_Connect.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Connect.ForeColor = System.Drawing.Color.White
        Me.Button_Connect.Location = New System.Drawing.Point(241, 31)
        Me.Button_Connect.Name = "Button_Connect"
        Me.Button_Connect.Size = New System.Drawing.Size(75, 23)
        Me.Button_Connect.TabIndex = 1
        Me.Button_Connect.Text = "Connect"
        Me.Button_Connect.UseVisualStyleBackColor = False
        '
        'ComBox_Comports
        '
        Me.ComBox_Comports.BackColor = System.Drawing.Color.White
        Me.ComBox_Comports.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComBox_Comports.ForeColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(1, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.ComBox_Comports.FormattingEnabled = True
        Me.ComBox_Comports.Location = New System.Drawing.Point(21, 31)
        Me.ComBox_Comports.Name = "ComBox_Comports"
        Me.ComBox_Comports.Size = New System.Drawing.Size(121, 24)
        Me.ComBox_Comports.TabIndex = 3
        '
        'GroupBox_BatteryVoltage
        '
        Me.GroupBox_BatteryVoltage.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_BatteryVoltage.Controls.Add(Me.ProgressBar_Voltage)
        Me.GroupBox_BatteryVoltage.Controls.Add(Me.Label_Battery_Voltage)
        Me.GroupBox_BatteryVoltage.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_BatteryVoltage.ForeColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(1, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.GroupBox_BatteryVoltage.Location = New System.Drawing.Point(414, 401)
        Me.GroupBox_BatteryVoltage.Name = "GroupBox_BatteryVoltage"
        Me.GroupBox_BatteryVoltage.Size = New System.Drawing.Size(368, 75)
        Me.GroupBox_BatteryVoltage.TabIndex = 39
        Me.GroupBox_BatteryVoltage.TabStop = False
        Me.GroupBox_BatteryVoltage.Text = "Battery Voltage"
        '
        'ProgressBar_Voltage
        '
        Me.ProgressBar_Voltage.Location = New System.Drawing.Point(102, 33)
        Me.ProgressBar_Voltage.Maximum = 255
        Me.ProgressBar_Voltage.Name = "ProgressBar_Voltage"
        Me.ProgressBar_Voltage.Size = New System.Drawing.Size(170, 23)
        Me.ProgressBar_Voltage.TabIndex = 42
        '
        'Label_Battery_Voltage
        '
        Me.Label_Battery_Voltage.AutoSize = True
        Me.Label_Battery_Voltage.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Battery_Voltage.Location = New System.Drawing.Point(298, 33)
        Me.Label_Battery_Voltage.Name = "Label_Battery_Voltage"
        Me.Label_Battery_Voltage.Size = New System.Drawing.Size(43, 18)
        Me.Label_Battery_Voltage.TabIndex = 41
        Me.Label_Battery_Voltage.Text = "0.0 V"
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.Label_Connection_RP6)
        Me.GroupBox9.Controls.Add(Me.Label_Dongle_Status)
        Me.GroupBox9.Controls.Add(Me.Label12)
        Me.GroupBox9.Controls.Add(Me.Label61)
        Me.GroupBox9.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(1, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.GroupBox9.Location = New System.Drawing.Point(22, 107)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(364, 105)
        Me.GroupBox9.TabIndex = 60
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Status "
        '
        'Label_Connection_RP6
        '
        Me.Label_Connection_RP6.AutoSize = True
        Me.Label_Connection_RP6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Connection_RP6.ForeColor = System.Drawing.Color.DarkRed
        Me.Label_Connection_RP6.Location = New System.Drawing.Point(284, 64)
        Me.Label_Connection_RP6.Name = "Label_Connection_RP6"
        Me.Label_Connection_RP6.Size = New System.Drawing.Size(13, 16)
        Me.Label_Connection_RP6.TabIndex = 3
        Me.Label_Connection_RP6.Text = "-"
        '
        'Label_Dongle_Status
        '
        Me.Label_Dongle_Status.AutoSize = True
        Me.Label_Dongle_Status.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Dongle_Status.ForeColor = System.Drawing.Color.DarkRed
        Me.Label_Dongle_Status.Location = New System.Drawing.Point(283, 42)
        Me.Label_Dongle_Status.Name = "Label_Dongle_Status"
        Me.Label_Dongle_Status.Size = New System.Drawing.Size(70, 16)
        Me.Label_Dongle_Status.TabIndex = 2
        Me.Label_Dongle_Status.Text = "Not Found "
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(21, 62)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(154, 16)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "Connection RP6 Arduino: "
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label61.Location = New System.Drawing.Point(21, 37)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(108, 16)
        Me.Label61.TabIndex = 0
        Me.Label61.Text = "Wireless dongle: "
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.Main1)
        Me.TabControl1.Controls.Add(Me.Settings1)
        Me.TabControl1.Controls.Add(Me.Status)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(814, 532)
        Me.TabControl1.TabIndex = 61
        '
        'Main1
        '
        Me.Main1.BackColor = System.Drawing.SystemColors.Control
        Me.Main1.Controls.Add(Me.Label7)
        Me.Main1.Controls.Add(Me.Label1)
        Me.Main1.Controls.Add(Me.GroupBox3)
        Me.Main1.Controls.Add(Me.GroupBox2)
        Me.Main1.Controls.Add(Me.GroupBox1)
        Me.Main1.Controls.Add(Me.GroupBox_connection)
        Me.Main1.Controls.Add(Me.GroupBox_BatteryVoltage)
        Me.Main1.Controls.Add(Me.GroupBox9)
        Me.Main1.Location = New System.Drawing.Point(4, 22)
        Me.Main1.Name = "Main1"
        Me.Main1.Padding = New System.Windows.Forms.Padding(3)
        Me.Main1.Size = New System.Drawing.Size(806, 506)
        Me.Main1.TabIndex = 0
        Me.Main1.Text = "Main"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label7.Location = New System.Drawing.Point(92, 440)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(192, 29)
        Me.Label7.TabIndex = 66
        Me.Label7.Text = "Control Software"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label1.Location = New System.Drawing.Point(36, 401)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(339, 37)
        Me.Label1.TabIndex = 65
        Me.Label1.Text = "AREXX Arduino Robot"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.ProgressBar_Speed_Right)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.ProgressBar_Speed_Left)
        Me.GroupBox3.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(1, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.GroupBox3.Location = New System.Drawing.Point(414, 279)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(368, 111)
        Me.GroupBox3.TabIndex = 64
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Speed"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(18, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 16)
        Me.Label4.TabIndex = 63
        Me.Label4.Text = "Motor Right"
        '
        'ProgressBar_Speed_Right
        '
        Me.ProgressBar_Speed_Right.Location = New System.Drawing.Point(102, 67)
        Me.ProgressBar_Speed_Right.Maximum = 255
        Me.ProgressBar_Speed_Right.Name = "ProgressBar_Speed_Right"
        Me.ProgressBar_Speed_Right.Size = New System.Drawing.Size(170, 23)
        Me.ProgressBar_Speed_Right.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(17, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 16)
        Me.Label5.TabIndex = 62
        Me.Label5.Text = "Motor Left"
        '
        'ProgressBar_Speed_Left
        '
        Me.ProgressBar_Speed_Left.Location = New System.Drawing.Point(102, 34)
        Me.ProgressBar_Speed_Left.Maximum = 255
        Me.ProgressBar_Speed_Left.Name = "ProgressBar_Speed_Left"
        Me.ProgressBar_Speed_Left.Size = New System.Drawing.Size(170, 23)
        Me.ProgressBar_Speed_Left.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.HScrollBar_Speed)
        Me.GroupBox2.Controls.Add(Me.Button_Backward)
        Me.GroupBox2.Controls.Add(Me.Button_Right)
        Me.GroupBox2.Controls.Add(Me.Button_Forward)
        Me.GroupBox2.Controls.Add(Me.Button_Left)
        Me.GroupBox2.Controls.Add(Me.Button_Stop)
        Me.GroupBox2.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(1, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.GroupBox2.Location = New System.Drawing.Point(414, 27)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(368, 246)
        Me.GroupBox2.TabIndex = 63
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Control"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(48, 202)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 16)
        Me.Label6.TabIndex = 79
        Me.Label6.Text = "Speed"
        '
        'HScrollBar_Speed
        '
        Me.HScrollBar_Speed.Location = New System.Drawing.Point(120, 194)
        Me.HScrollBar_Speed.Maximum = 255
        Me.HScrollBar_Speed.Name = "HScrollBar_Speed"
        Me.HScrollBar_Speed.Size = New System.Drawing.Size(179, 29)
        Me.HScrollBar_Speed.TabIndex = 78
        Me.HScrollBar_Speed.Value = 128
        '
        'Button_Backward
        '
        Me.Button_Backward.BackColor = System.Drawing.Color.SteelBlue
        Me.Button_Backward.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Backward.ForeColor = System.Drawing.Color.White
        Me.Button_Backward.Location = New System.Drawing.Point(133, 135)
        Me.Button_Backward.Name = "Button_Backward"
        Me.Button_Backward.Size = New System.Drawing.Size(105, 40)
        Me.Button_Backward.TabIndex = 77
        Me.Button_Backward.Text = "Backward"
        Me.Button_Backward.UseVisualStyleBackColor = False
        '
        'Button_Right
        '
        Me.Button_Right.BackColor = System.Drawing.Color.SteelBlue
        Me.Button_Right.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Right.ForeColor = System.Drawing.Color.White
        Me.Button_Right.Location = New System.Drawing.Point(250, 75)
        Me.Button_Right.Name = "Button_Right"
        Me.Button_Right.Size = New System.Drawing.Size(91, 40)
        Me.Button_Right.TabIndex = 76
        Me.Button_Right.Text = "Right"
        Me.Button_Right.UseVisualStyleBackColor = False
        '
        'Button_Forward
        '
        Me.Button_Forward.BackColor = System.Drawing.Color.SteelBlue
        Me.Button_Forward.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Forward.ForeColor = System.Drawing.Color.White
        Me.Button_Forward.Location = New System.Drawing.Point(133, 15)
        Me.Button_Forward.Name = "Button_Forward"
        Me.Button_Forward.Size = New System.Drawing.Size(105, 40)
        Me.Button_Forward.TabIndex = 75
        Me.Button_Forward.Text = "Forward"
        Me.Button_Forward.UseVisualStyleBackColor = False
        '
        'Button_Left
        '
        Me.Button_Left.BackColor = System.Drawing.Color.SteelBlue
        Me.Button_Left.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Left.ForeColor = System.Drawing.Color.White
        Me.Button_Left.Location = New System.Drawing.Point(21, 75)
        Me.Button_Left.Name = "Button_Left"
        Me.Button_Left.Size = New System.Drawing.Size(91, 40)
        Me.Button_Left.TabIndex = 74
        Me.Button_Left.Text = "Left"
        Me.Button_Left.UseVisualStyleBackColor = False
        '
        'Button_Stop
        '
        Me.Button_Stop.BackColor = System.Drawing.Color.SteelBlue
        Me.Button_Stop.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Stop.ForeColor = System.Drawing.Color.White
        Me.Button_Stop.Location = New System.Drawing.Point(139, 61)
        Me.Button_Stop.Name = "Button_Stop"
        Me.Button_Stop.Size = New System.Drawing.Size(91, 69)
        Me.Button_Stop.TabIndex = 72
        Me.Button_Stop.Text = "Stop"
        Me.Button_Stop.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.LineCheck)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.ProgressBar_Current_Left)
        Me.GroupBox1.Controls.Add(Me.ProgressBar_Current_Right)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(1, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(22, 248)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(364, 142)
        Me.GroupBox1.TabIndex = 62
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Line Sensor"
        '
        'LineCheck
        '
        Me.LineCheck.AutoSize = True
        Me.LineCheck.Location = New System.Drawing.Point(25, 103)
        Me.LineCheck.Name = "LineCheck"
        Me.LineCheck.Size = New System.Drawing.Size(101, 22)
        Me.LineCheck.TabIndex = 7
        Me.LineCheck.Text = "Led On/Off"
        Me.LineCheck.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(22, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 16)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Right"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(21, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Left"
        '
        'ProgressBar_Current_Left
        '
        Me.ProgressBar_Current_Left.Location = New System.Drawing.Point(115, 67)
        Me.ProgressBar_Current_Left.Name = "ProgressBar_Current_Left"
        Me.ProgressBar_Current_Left.Size = New System.Drawing.Size(182, 23)
        Me.ProgressBar_Current_Left.TabIndex = 1
        '
        'ProgressBar_Current_Right
        '
        Me.ProgressBar_Current_Right.Location = New System.Drawing.Point(115, 34)
        Me.ProgressBar_Current_Right.Name = "ProgressBar_Current_Right"
        Me.ProgressBar_Current_Right.Size = New System.Drawing.Size(182, 23)
        Me.ProgressBar_Current_Right.TabIndex = 0
        '
        'Settings1
        '
        Me.Settings1.BackColor = System.Drawing.SystemColors.Control
        Me.Settings1.Controls.Add(Me.GroupBox7)
        Me.Settings1.Controls.Add(Me.GroupBox_Settings)
        Me.Settings1.Location = New System.Drawing.Point(4, 22)
        Me.Settings1.Name = "Settings1"
        Me.Settings1.Padding = New System.Windows.Forms.Padding(3)
        Me.Settings1.Size = New System.Drawing.Size(806, 506)
        Me.Settings1.TabIndex = 1
        Me.Settings1.Text = "Settings"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.ComboBox1)
        Me.GroupBox7.Controls.Add(Me.Label34)
        Me.GroupBox7.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(1, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.GroupBox7.Location = New System.Drawing.Point(507, 16)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(280, 94)
        Me.GroupBox7.TabIndex = 62
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Serial"
        '
        'ComboBox1
        '
        Me.ComboBox1.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.ComboBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(1, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"1200", "2400", "4800", "9600", "19200", "38400", "57600"})
        Me.ComboBox1.Location = New System.Drawing.Point(150, 34)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(88, 24)
        Me.ComboBox1.TabIndex = 2
        Me.ComboBox1.Text = "9600"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(21, 39)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(93, 16)
        Me.Label34.TabIndex = 1
        Me.Label34.Text = "Serial Bautrate"
        '
        'GroupBox_Settings
        '
        Me.GroupBox_Settings.Controls.Add(Me.Label20)
        Me.GroupBox_Settings.Controls.Add(Me.Label19)
        Me.GroupBox_Settings.Controls.Add(Me.Panel_Settings)
        Me.GroupBox_Settings.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_Settings.ForeColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(1, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.GroupBox_Settings.Location = New System.Drawing.Point(15, 16)
        Me.GroupBox_Settings.Name = "GroupBox_Settings"
        Me.GroupBox_Settings.Size = New System.Drawing.Size(474, 382)
        Me.GroupBox_Settings.TabIndex = 4
        Me.GroupBox_Settings.TabStop = False
        Me.GroupBox_Settings.Text = "Settings APC220"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(89, 354)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(236, 16)
        Me.Label20.TabIndex = 63
        Me.Label20.Text = "you purchase a wireless RP6 arduino kit"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(53, 338)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(354, 16)
        Me.Label19.TabIndex = 62
        Me.Label19.Text = "Note: You can only change the settings of the APC220 when "
        '
        'Panel_Settings
        '
        Me.Panel_Settings.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Panel_Settings.Location = New System.Drawing.Point(6, 18)
        Me.Panel_Settings.Name = "Panel_Settings"
        Me.Panel_Settings.Size = New System.Drawing.Size(461, 318)
        Me.Panel_Settings.TabIndex = 0
        '
        'Status
        '
        Me.Status.BackColor = System.Drawing.SystemColors.Control
        Me.Status.Controls.Add(Me.Button_Test_Communication)
        Me.Status.Controls.Add(Me.TextBox_Test_Status)
        Me.Status.Controls.Add(Me.GroupBox6)
        Me.Status.Controls.Add(Me.GroupBox5)
        Me.Status.Location = New System.Drawing.Point(4, 22)
        Me.Status.Name = "Status"
        Me.Status.Padding = New System.Windows.Forms.Padding(3)
        Me.Status.Size = New System.Drawing.Size(806, 506)
        Me.Status.TabIndex = 3
        Me.Status.Text = "Status"
        '
        'Button_Test_Communication
        '
        Me.Button_Test_Communication.BackColor = System.Drawing.Color.SteelBlue
        Me.Button_Test_Communication.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Test_Communication.ForeColor = System.Drawing.Color.White
        Me.Button_Test_Communication.Location = New System.Drawing.Point(559, 357)
        Me.Button_Test_Communication.Name = "Button_Test_Communication"
        Me.Button_Test_Communication.Size = New System.Drawing.Size(117, 42)
        Me.Button_Test_Communication.TabIndex = 66
        Me.Button_Test_Communication.Text = "Test Communication"
        Me.Button_Test_Communication.UseVisualStyleBackColor = False
        '
        'TextBox_Test_Status
        '
        Me.TextBox_Test_Status.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.TextBox_Test_Status.ForeColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(1, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.TextBox_Test_Status.Location = New System.Drawing.Point(473, 57)
        Me.TextBox_Test_Status.Multiline = True
        Me.TextBox_Test_Status.Name = "TextBox_Test_Status"
        Me.TextBox_Test_Status.Size = New System.Drawing.Size(275, 270)
        Me.TextBox_Test_Status.TabIndex = 64
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label_start_time_application)
        Me.GroupBox6.Controls.Add(Me.Label_Time_Connected)
        Me.GroupBox6.Controls.Add(Me.Label26)
        Me.GroupBox6.Controls.Add(Me.Label27)
        Me.GroupBox6.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(1, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.GroupBox6.Location = New System.Drawing.Point(32, 221)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(364, 106)
        Me.GroupBox6.TabIndex = 63
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Application"
        '
        'Label_start_time_application
        '
        Me.Label_start_time_application.AutoSize = True
        Me.Label_start_time_application.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_start_time_application.Location = New System.Drawing.Point(255, 70)
        Me.Label_start_time_application.Name = "Label_start_time_application"
        Me.Label_start_time_application.Size = New System.Drawing.Size(79, 16)
        Me.Label_start_time_application.TabIndex = 90
        Me.Label_start_time_application.Text = "00:00:00:00"
        '
        'Label_Time_Connected
        '
        Me.Label_Time_Connected.AutoSize = True
        Me.Label_Time_Connected.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Time_Connected.Location = New System.Drawing.Point(255, 40)
        Me.Label_Time_Connected.Name = "Label_Time_Connected"
        Me.Label_Time_Connected.Size = New System.Drawing.Size(79, 16)
        Me.Label_Time_Connected.TabIndex = 89
        Me.Label_Time_Connected.Text = "00:00:00:00"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(21, 70)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(135, 16)
        Me.Label26.TabIndex = 88
        Me.Label26.Text = "Start time application:"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(21, 40)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(106, 16)
        Me.Label27.TabIndex = 87
        Me.Label27.Text = "Time Connected:"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label_transmitted_packets)
        Me.GroupBox5.Controls.Add(Me.Label_received_packets)
        Me.GroupBox5.Controls.Add(Me.Label24)
        Me.GroupBox5.Controls.Add(Me.Label23)
        Me.GroupBox5.Controls.Add(Me.Label_Wrong_Packets)
        Me.GroupBox5.Controls.Add(Me.Label21)
        Me.GroupBox5.Controls.Add(Me.Label_Wrong_Packets_RP6)
        Me.GroupBox5.Controls.Add(Me.Label25)
        Me.GroupBox5.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(1, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.GroupBox5.Location = New System.Drawing.Point(32, 49)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(364, 166)
        Me.GroupBox5.TabIndex = 61
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Status "
        '
        'Label_transmitted_packets
        '
        Me.Label_transmitted_packets.AutoSize = True
        Me.Label_transmitted_packets.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_transmitted_packets.Location = New System.Drawing.Point(282, 41)
        Me.Label_transmitted_packets.Name = "Label_transmitted_packets"
        Me.Label_transmitted_packets.Size = New System.Drawing.Size(15, 16)
        Me.Label_transmitted_packets.TabIndex = 6
        Me.Label_transmitted_packets.Text = "0"
        '
        'Label_received_packets
        '
        Me.Label_received_packets.AutoSize = True
        Me.Label_received_packets.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_received_packets.Location = New System.Drawing.Point(282, 70)
        Me.Label_received_packets.Name = "Label_received_packets"
        Me.Label_received_packets.Size = New System.Drawing.Size(15, 16)
        Me.Label_received_packets.TabIndex = 5
        Me.Label_received_packets.Text = "0"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(21, 70)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(172, 16)
        Me.Label24.TabIndex = 4
        Me.Label24.Text = "Number of received packets:"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(21, 40)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(189, 16)
        Me.Label23.TabIndex = 2
        Me.Label23.Text = "Number of transmitted packets:"
        '
        'Label_Wrong_Packets
        '
        Me.Label_Wrong_Packets.AutoSize = True
        Me.Label_Wrong_Packets.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Wrong_Packets.Location = New System.Drawing.Point(284, 99)
        Me.Label_Wrong_Packets.Name = "Label_Wrong_Packets"
        Me.Label_Wrong_Packets.Size = New System.Drawing.Size(15, 16)
        Me.Label_Wrong_Packets.TabIndex = 3
        Me.Label_Wrong_Packets.Text = "0"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(21, 125)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(199, 16)
        Me.Label21.TabIndex = 1
        Me.Label21.Text = "Wrong received packets by AAR: "
        '
        'Label_Wrong_Packets_RP6
        '
        Me.Label_Wrong_Packets_RP6.AutoSize = True
        Me.Label_Wrong_Packets_RP6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Wrong_Packets_RP6.Location = New System.Drawing.Point(284, 128)
        Me.Label_Wrong_Packets_RP6.Name = "Label_Wrong_Packets_RP6"
        Me.Label_Wrong_Packets_RP6.Size = New System.Drawing.Size(15, 16)
        Me.Label_Wrong_Packets_RP6.TabIndex = 2
        Me.Label_Wrong_Packets_RP6.Text = "0"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(21, 100)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(237, 16)
        Me.Label25.TabIndex = 0
        Me.Label25.Text = "Wrong received packets by Application: "
        '
        'Timer_RF_Test
        '
        Me.Timer_RF_Test.Interval = 1000
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(838, 556)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "Main"
        Me.Text = "AREXX Arduino Robot"
        Me.GroupBox_connection.ResumeLayout(False)
        Me.GroupBox_BatteryVoltage.ResumeLayout(False)
        Me.GroupBox_BatteryVoltage.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.Main1.ResumeLayout(False)
        Me.Main1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Settings1.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox_Settings.ResumeLayout(False)
        Me.GroupBox_Settings.PerformLayout()
        Me.Status.ResumeLayout(False)
        Me.Status.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SerialPort_APC220 As System.IO.Ports.SerialPort
    Friend WithEvents Timer_ASK_Data As System.Windows.Forms.Timer
    Friend WithEvents Timer_Connection_Check As System.Windows.Forms.Timer
    Friend WithEvents Timer_WT_Timeout As System.Windows.Forms.Timer
    Friend WithEvents GroupBox_connection As System.Windows.Forms.GroupBox
    Friend WithEvents Button_refresh_comport As System.Windows.Forms.Button
    Friend WithEvents Button_Connect As System.Windows.Forms.Button
    Friend WithEvents ComBox_Comports As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox_BatteryVoltage As System.Windows.Forms.GroupBox
    Friend WithEvents ProgressBar_Voltage As System.Windows.Forms.ProgressBar
    Friend WithEvents Label_Battery_Voltage As System.Windows.Forms.Label
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents Label_Connection_RP6 As System.Windows.Forms.Label
    Friend WithEvents Label_Dongle_Status As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Main1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar_Speed_Right As System.Windows.Forms.ProgressBar
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar_Speed_Left As System.Windows.Forms.ProgressBar
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button_Backward As System.Windows.Forms.Button
    Friend WithEvents Button_Right As System.Windows.Forms.Button
    Friend WithEvents Button_Forward As System.Windows.Forms.Button
    Friend WithEvents Button_Left As System.Windows.Forms.Button
    Friend WithEvents Button_Stop As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar_Current_Left As System.Windows.Forms.ProgressBar
    Friend WithEvents ProgressBar_Current_Right As System.Windows.Forms.ProgressBar
    Friend WithEvents Settings1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox_Settings As System.Windows.Forms.GroupBox
    Friend WithEvents Panel_Settings As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents HScrollBar_Speed As System.Windows.Forms.HScrollBar
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Status As System.Windows.Forms.TabPage
    Friend WithEvents Label_Wrong_Packets As System.Windows.Forms.Label
    Friend WithEvents Label_Wrong_Packets_RP6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label_transmitted_packets As System.Windows.Forms.Label
    Friend WithEvents Label_received_packets As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TextBox_Test_Status As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Button_Test_Communication As System.Windows.Forms.Button
    Friend WithEvents Timer_RF_Test As System.Windows.Forms.Timer
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label_start_time_application As System.Windows.Forms.Label
    Friend WithEvents Label_Time_Connected As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents LineCheck As System.Windows.Forms.CheckBox

End Class
