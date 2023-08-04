Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms


	Partial Public Class TangentsForm
		Inherits Form

		Public Sub New()
			InitializeComponent()
			Me.lineRadioButton.Checked = True

		End Sub
        
		Private Sub selectButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles selectButton.Click
			Me.Close()
			Me.DialogResult = System.Windows.Forms.DialogResult.OK

		End Sub

		Private Sub radioButton1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles lineRadioButton.CheckedChanged
			CircleTangents = circlesRadioButton.Checked
			LineTangents = lineRadioButton.Checked
			radiusLabel.Enabled = circlesRadioButton.Checked
			radiusTextBox.Enabled=circlesRadioButton.Checked
			optionsGruopBox.Enabled=circlesRadioButton.Checked

		End Sub

		Private Sub circlesRadioButton_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles circlesRadioButton.CheckedChanged
			CircleTangents = circlesRadioButton.Checked
			LineTangents = lineRadioButton.Checked
			radiusLabel.Enabled = circlesRadioButton.Checked
			radiusTextBox.Enabled=circlesRadioButton.Checked
			optionsGruopBox.Enabled=circlesRadioButton.Checked
		End Sub

		Private Sub textBox1_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles radiusTextBox.TextChanged
			Dim val As Double = Nothing
			If Double.TryParse(radiusTextBox.Text, val) Then
			    TangentRadius = val
			End If

		End Sub
        Public TangentRadius As Double=10
		

		Public Property LineTangents() As Boolean

		Public Property CircleTangents() As Boolean

		Public Property TrimTangents() As Boolean

		Public Property FlipTangents() As Boolean

		Private Sub checkBox2_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles trimCheckBox.CheckedChanged
			TrimTangents = trimCheckBox.Checked
		End Sub

		Private Sub flipCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles flipCheckBox.CheckedChanged
			FlipTangents = flipCheckBox.Checked
		End Sub


	End Class

