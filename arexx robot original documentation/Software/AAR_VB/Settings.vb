Public Class Settings

    'In de variabele freq_store wordt de waarde van de frequentie opgeslagen voordat deze wordt gewijzigd. 
    'Wanneer er een foutieve frequentie wordt ingevoerd, wordt uit deze variabele geladen 
    Dim freq_store As String

    'Wanneer nieuwe setting worden geschreven naar de APC220, is deze variabele geactiveerd 
    Dim Write_active As Boolean



    Private Sub Settings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Bij het laden van het programma
        'set tooltip bij textbox frequentie, zodat gebruiker weet welke waardes ingevuld kunnen worden
        ToolTip1.SetToolTip(TextBox_Freq, "Enter a frequency between 418,000 and 455,000 MHz")

        Me.TopLevel = False

    End Sub

    Public Sub Handles_APCdata_settings()
        'Wanneer er settings zijn veranderd, of settings wordt uitgelezen stuurt de APC zijn gegevens naar de applicatie
        'Deze data wordt in deze functie verwerkt en in de textboxen en comboboxen geschreven. 

        'Try, om ervoor te zorgen wanneer de data niet goed binnenkomt, het programma niet vast loopt 
        Try
            'De eerste 5 bytes bestaat uit "PARA " daarna volgt de informatie 
            TextBox_Freq.Text = Main.ontvangendata.Substring(5, 3)      'De eerste 3 bytes staat voor de frequentie (voor de komma)
            TextBox_Freq.Text += ","                                    'Plaats een komma in de textbox 
            TextBox_Freq.Text += Main.ontvangendata.Substring(8, 3)     'De volgende 3 bytes staat voor de frequentie (na de komma) 
            'spatie! Gevolgd door de RF data rate (plek 12)
            ComBox_TRxRate.SelectedIndex = Main.ontvangendata.Substring(12, 1) - 1      'Deze waarde staat gelijk aan de combobox index -1
            'spatie! Gevolgd door de RF data rate (plek 14)
            ComBox_RF_Power.SelectedIndex = Main.ontvangendata.Substring(14, 1)         'Deze waarde staat gelijk aan de combobox index 
            'spatie! Gevolgd door de RF data rate (plek 16)
            ComBox_Series_Rate.SelectedIndex = Main.ontvangendata.Substring(16, 1)      'Deze waarde staat gelijk aan de combobox index 
            'spatie! Gevolgd door de RF data rate (plek 18)
            ComBox_Series_Patity.SelectedIndex = Main.ontvangendata.Substring(18, 1)    'Deze waarde staat gelijk aan de combobox index 
        Catch ex As Exception
        End Try

        'stop timer, geen timeout gedetecteerd 
        Timer_Settings_RW.Stop()

        If Write_active Then

            log_write_time()    'Schrijf de tijd in de log box 
            'Geef melding in de text logbox dat het schrijven is gelukt + Return and Line Feed
            TextBox_Log_APC.Text += "Write succes! ....." & ControlChars.CrLf
            'reset Write active 
            Write_active = False
        End If

        log_write_time()    'Schrijf de tijd in de log box 
        'Geef melding in de text logbox dat het lezen is gelukt + Return and Line Feed
        TextBox_Log_APC.Text += "Read succes! ....." & ControlChars.CrLf

        'maak ontvangst buffer leeg 
        Main.SerialPort_APC220.DiscardInBuffer()

        'Start data timer om data opvraag te starten 
        Main.Timer_ASK_Data.Start()

        'Timer voor timeout detectie resetten 
        Main.Timer_WT_Timeout.Enabled = False
        Main.Timer_WT_Timeout.Enabled = True

    End Sub

    Private Sub Button_Write_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Write.Click
        'In deze functie worden de nieuwe parameters naar de APC220 geschreven,
        'Zie datasheet van de APC220 voor het protocol 

        'Controleer of de seriele poort is geopend, zo niet dan wordt er een melding gegeven 
        If Main.SerialPort_APC220.IsOpen = False Then
            MsgBox(" Can't find the wireless dongle ")

            log_write_time()    'Schrijf de tijd in de log box 
            'Geef melding in de text logbox dat het schrijven is mislukt + Return and Line Feed
            TextBox_Log_APC.Text += "Write fail! ....." & ControlChars.CrLf
            Return
        End If

        'Stop met het vragen van data vanuit de wild Thumper 
        Main.Timer_ASK_Data.Stop()

        'maak ontvangst buffer leeg 
        Main.SerialPort_APC220.DiscardInBuffer()

        'Geef aan dat er geschreven wordt, dit is nodig om de terugkoppeling te verwerken. 
        Write_active = True

        'Maak DTR laag, let op DTR is geinverteerd!!!
        'DTR is aangesloten op de SET ingang van de APC220 
        Main.SerialPort_APC220.DtrEnable = True

        'wacht 250 ms 
        System.Threading.Thread.Sleep(250)

        'start timer voor het detecteren van een timeout vanaf de APC220 
        Timer_Settings_RW.Start()

        'Write command and space 
        Main.SerialPort_APC220.Write("W")
        Main.SerialPort_APC220.Write("R")
        Main.SerialPort_APC220.Write(" ")

        'frequentie and space 
        'Haal de frequentie uit de textbox 
        Dim RF_Freq As String = TextBox_Freq.Text.ToString
        'Elke nummer wordt naar de seriele poort geschreven
        'behalve de komma (op plek 3) 
        Main.SerialPort_APC220.Write(RF_Freq.Substring(0, 1))     'Het eerste cijfer van het getal 
        Main.SerialPort_APC220.Write(RF_Freq.Substring(1, 1))     'Het tweede cijfer van het getal 
        Main.SerialPort_APC220.Write(RF_Freq.Substring(2, 1))     'Het derde cijfer van het getal 
        'Het vierde cijfer is de komma, deze heeft niet verstuurd te worden!!!    
        Main.SerialPort_APC220.Write(RF_Freq.Substring(4, 1))     'Het vijde cijfer van het getal 
        Main.SerialPort_APC220.Write(RF_Freq.Substring(5, 1))     'Het zesde cijfer van het getal 
        Main.SerialPort_APC220.Write(RF_Freq.Substring(6, 1))     'Het zevende cijfer van het getal 
        Main.SerialPort_APC220.Write(" ")

        'RF Data Rate and space
        'De index van combobox + 1 staat gelijk aan de waarde voor de APC220 (zie datasheet)
        Dim TRxRate As String = ComBox_TRxRate.SelectedIndex.ToString + 1
        Main.SerialPort_APC220.Write(TRxRate)
        Main.SerialPort_APC220.Write(" ")

        ' Output Power and space
        'De index van combobox staat gelijk aan de waarde voor de APC220 (zie datasheet)
        Dim RF_Power As String = ComBox_RF_Power.SelectedIndex.ToString
        Main.SerialPort_APC220.Write(RF_Power)
        Main.SerialPort_APC220.Write(" ")

        ' UartRate and space
        'De index van combobox staat gelijk aan de waarde voor de APC220 (zie datasheet)
        Dim Series_Rate As String = ComBox_Series_Rate.SelectedIndex.ToString
        Main.SerialPort_APC220.Write(Series_Rate)
        Main.SerialPort_APC220.Write(" ")

        ' Series Patity WITHOUT space !!
        'De index van combobox staat gelijk aan de waarde voor de APC220 (zie datasheet)
        Dim Series_Patity As String = ComBox_Series_Patity.SelectedIndex.ToString
        Main.SerialPort_APC220.Write(Series_Patity)

        ' Send Carriage Return and Line Feed
        Main.SerialPort_APC220.Write(ControlChars.CrLf)

        'maak ontvangst buffer leeg 
        Main.SerialPort_APC220.DiscardInBuffer()

        'delay van 250ms 
        System.Threading.Thread.Sleep(250)
        'Zet dtr hoog, let op DTR is geinverteerd!!!
        'DTR is aangesloten op de SET ingang van de APC220 
        Main.SerialPort_APC220.DtrEnable = False

    End Sub

    Private Sub Button_Read_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Read.Click

        'Controleer of de seriele poort is geopend, zo niet dan wordt er een melding gegeven 
        If Main.SerialPort_APC220.IsOpen = False Then
            MsgBox(" Can't find the wireless dongle ")
            log_write_time()    'Schrijf de tijd in de log box 
            'Geef melding in de text logbox dat het lezen is mislukt + Return and Line Feed
            TextBox_Log_APC.Text += "Read fail! ......" & ControlChars.CrLf
            Return
        End If

        'Stop met het vragen van data vanuit de wild Thumper 
        Main.Timer_ASK_Data.Stop()

        'Maak buffer leeg 
        Main.SerialPort_APC220.DiscardInBuffer()

        'Maak DTR laag, let op DTR is geinverteerd!!!
        'DTR is aangesloten op de SET ingang van de APC220 
        Main.SerialPort_APC220.DtrEnable = True

        'wacht 250ms 
        System.Threading.Thread.Sleep(250)

        'start timer voor het detecteren van een timeout vanaf de APC220 
        Timer_Settings_RW.Start()

        'Schrijf start commando om data uit te lezen "RD"
        Main.SerialPort_APC220.Write("R")
        Main.SerialPort_APC220.Write("D")

        ' Send Carriage Return and Line Feed
        Main.SerialPort_APC220.Write(ControlChars.CrLf)

        'maak ontvangst buffer leeg 
        Main.SerialPort_APC220.DiscardInBuffer()

        'delay van 250ms 
        System.Threading.Thread.Sleep(250)

        'Maak DTR hoog, let op DTR is geinverteerd!!!
        'DTR is aangesloten op de SET ingang van de APC220 
        Main.SerialPort_APC220.DtrEnable = False
    End Sub

    Private Sub Button_Default_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Default.Click
        'Zet de transeiver terug naar zijn begin waardes, deze komen over een met de begin waardes van de Wild Thumper 
        TextBox_Freq.Text = "433,000"                   'frequentie = 433,000 MHz 
        ComBox_TRxRate.SelectedIndex = "2"              'RF data rate = 9600 bps 
        ComBox_RF_Power.SelectedIndex = "5"             'RF power = 5 (ongeveer 10mW) 
        ComBox_Series_Rate.SelectedIndex = "3"          'Seriele bautrate = 9600 bps 
        ComBox_Series_Patity.SelectedIndex = "0"        'Parity check = disable 

        log_write_time()     'Schrijf de tijd in de log box 
        'Geef melding in de text logbox dat default values zijn geset + Return and Line Feed
        TextBox_Log_APC.Text += "Set default values" & ControlChars.CrLf

    End Sub

    Private Sub TextBox_Freq_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox_Freq.Enter
        'Zodra er een nieuwe frequentie wordt ingevoerd, zal de oude waarde worden opgeslagen
        'Deze waarde zal weer worden ingevoerd als er een foutieve frequentie wordt ingevoerd. 
        freq_store = TextBox_Freq.Text
    End Sub

    Private Sub TextBox_Freq_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox_Freq.Leave
        'Wanneer er een nieuwe frequentie wordt ingevoerd, moet deze aan de volgende eisen voldoen:
        ' - Tussen 418 en 455 liggen
        ' - Bestaan uit nummers 
        ' - Geen punt bevatten maar een komma
        ' in deze functie wordt dit gecontroleerd en zonodig verholpen

        'variabelen 
        Dim RF_Freq As String = TextBox_Freq.Text.ToString
        Dim RF_Freq_Number As String
        Dim Freq_Double As Double

        'Verander de punt in een komma, zodat er mee gerekend kan worden. 
        RF_Freq_Number = RF_Freq.Replace(".", ",")

        'controle of het ingevoerde getal alleen uit nummers bestaat, ander wordt er een melding gegeven 
        If IsNumeric(RF_Freq_Number) = False Then
            MsgBox(" Enter a valid number ")
            'Zet vorige waarde weer terug in de tekstbox 
            TextBox_Freq.Text = freq_store

            'controle of de waarde binnen de grenzen ligt, anders wordt er een melding gegeven 
        Else

            'Zet de string om naar een double zodat achter de komma vergeleken kan worden
            Freq_Double = RF_Freq_Number

            If (Freq_Double < 418.0) Or (Freq_Double > 455.0) Then

                MsgBox(" Choose a value between 418 and 455 MHz! ")
                'Zet vorige waarde weer terug in de tekstbox 
                TextBox_Freq.Text = freq_store

                'Controle of nullen of komma toegevoegd moeten worden 
            ElseIf Len(RF_Freq) < 7 Then

                If Len(RF_Freq) < 4 Then
                    TextBox_Freq.Text += ","
                End If
                If Len(RF_Freq) < 5 Then
                    TextBox_Freq.Text += "0"
                End If
                If Len(RF_Freq) < 6 Then
                    TextBox_Freq.Text += "0"
                End If
                If Len(RF_Freq) < 7 Then
                    TextBox_Freq.Text += "0"
                End If


            End If

        End If

    End Sub

    Private Sub log_write_time()
        'Wanneer er text wordt in de log textbox wordt geschreven, wordt er eerst de tijd neer gezet 
        TextBox_Log_APC.Text += Now.ToLongTimeString + ":   "
    End Sub

    Private Sub TextBox_Log_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        TextBox_Log_APC.SelectionStart = TextBox_Log_APC.TextLength
        TextBox_Log_APC.ScrollToCaret()

    End Sub

    Private Sub Timer_Settings_RW_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Settings_RW.Tick
        'Wanneer settings worden geschreven of gelezen wordt deze timer gestart,
        'Als na 500ms nog geen reactie is verkregen, wordt hier een melding van gegegeven 
        Timer_Settings_RW.Stop()      'Stop de timer, zodat 1 keer de melding wordt gegeven 
        Write_active = False             'Reset write active!

        log_write_time()   'Schrijf de tijd in log box
        TextBox_Log_APC.Text += "Timeout ....." & ControlChars.CrLf

        MsgBox("Timeout: Wireless dongle doesn't react")        'geef melding 

        'start timer voor data opvraag
        Main.Timer_ASK_Data.Start()

    End Sub


End Class






