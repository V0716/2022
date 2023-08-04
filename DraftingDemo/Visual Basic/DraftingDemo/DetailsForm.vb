Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms


	Partial Public Class DetailsForm

		Inherits Form

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub closeButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles closeButton.Click
			Close()
		End Sub

		Private Sub copyToClipboardButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles copyToClipboardButton.Click
			Clipboard.SetText(contentTextBox.Text)
		End Sub
	End Class
