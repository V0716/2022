
    Partial Public Class TangentsForm
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.lineRadioButton = New System.Windows.Forms.RadioButton()
			Me.circlesRadioButton = New System.Windows.Forms.RadioButton()
			Me.flipCheckBox = New System.Windows.Forms.CheckBox()
			Me.trimCheckBox = New System.Windows.Forms.CheckBox()
			Me.radiusTextBox = New System.Windows.Forms.TextBox()
			Me.radiusLabel = New System.Windows.Forms.Label()
			Me.selectButton = New System.Windows.Forms.Button()
			Me.curveTypeGroupBox = New System.Windows.Forms.GroupBox()
			Me.optionsGruopBox = New System.Windows.Forms.GroupBox()
			Me.curveTypeGroupBox.SuspendLayout()
			Me.optionsGruopBox.SuspendLayout()
			Me.SuspendLayout()
			' 
			' lineRadioButton
			' 
			Me.lineRadioButton.AutoSize = True
			Me.lineRadioButton.Location = New System.Drawing.Point(9, 22)
			Me.lineRadioButton.Name = "lineRadioButton"
			Me.lineRadioButton.Size = New System.Drawing.Size(50, 17)
			Me.lineRadioButton.TabIndex = 0
			Me.lineRadioButton.TabStop = True
			Me.lineRadioButton.Text = "Lines"
			Me.lineRadioButton.UseVisualStyleBackColor = True

			' 
			' circlesRadioButton
			' 
			Me.circlesRadioButton.AutoSize = True
			Me.circlesRadioButton.Location = New System.Drawing.Point(9, 44)
			Me.circlesRadioButton.Name = "circlesRadioButton"
			Me.circlesRadioButton.Size = New System.Drawing.Size(56, 17)
			Me.circlesRadioButton.TabIndex = 1
			Me.circlesRadioButton.TabStop = True
			Me.circlesRadioButton.Text = "Circles"
			Me.circlesRadioButton.UseVisualStyleBackColor = True

			' 
			' flipCheckBox
			' 
			Me.flipCheckBox.AutoSize = True
			Me.flipCheckBox.Location = New System.Drawing.Point(12, 44)
			Me.flipCheckBox.Name = "flipCheckBox"
			Me.flipCheckBox.Size = New System.Drawing.Size(42, 17)
			Me.flipCheckBox.TabIndex = 2
			Me.flipCheckBox.Text = "Flip"
			Me.flipCheckBox.UseVisualStyleBackColor = True

			' 
			' trimCheckBox
			' 
			Me.trimCheckBox.AutoSize = True
			Me.trimCheckBox.Location = New System.Drawing.Point(12, 23)
			Me.trimCheckBox.Name = "trimCheckBox"
			Me.trimCheckBox.Size = New System.Drawing.Size(46, 17)
			Me.trimCheckBox.TabIndex = 3
			Me.trimCheckBox.Text = "Trim"
			Me.trimCheckBox.UseVisualStyleBackColor = True

			' 
			' tangentRadiusTextBox
			' 
			Me.radiusTextBox.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.radiusTextBox.Location = New System.Drawing.Point(138, 95)
			Me.radiusTextBox.Name = "radiusTextBox"
			Me.radiusTextBox.Size = New System.Drawing.Size(76, 20)
			Me.radiusTextBox.TabIndex = 4
			Me.radiusTextBox.Text = "10.0"
			Me.radiusTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right

			' 
			' radiusLabel
			' 
			Me.radiusLabel.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.radiusLabel.AutoSize = True
			Me.radiusLabel.Location = New System.Drawing.Point(24, 98)
			Me.radiusLabel.Name = "radiusLabel"
			Me.radiusLabel.Size = New System.Drawing.Size(106, 13)
			Me.radiusLabel.TabIndex = 5
			Me.radiusLabel.Text = "Tangent circle radius"
			' 
			' selectButton
			' 
			Me.selectButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.selectButton.Location = New System.Drawing.Point(148, 124)
			Me.selectButton.Name = "selectButton"
			Me.selectButton.Size = New System.Drawing.Size(66, 23)
			Me.selectButton.TabIndex = 6
			Me.selectButton.Text = "Select"
			Me.selectButton.UseVisualStyleBackColor = True

			' 
			' curveTypeGroupBox
			' 
			Me.curveTypeGroupBox.Controls.Add(Me.lineRadioButton)
			Me.curveTypeGroupBox.Controls.Add(Me.circlesRadioButton)
			Me.curveTypeGroupBox.Location = New System.Drawing.Point(12, 12)
			Me.curveTypeGroupBox.Name = "curveTypeGroupBox"
			Me.curveTypeGroupBox.Size = New System.Drawing.Size(114, 71)
			Me.curveTypeGroupBox.TabIndex = 7
			Me.curveTypeGroupBox.TabStop = False
			Me.curveTypeGroupBox.Text = "Output curve type"
			' 
			' optionsGruopBox
			' 
			Me.optionsGruopBox.Controls.Add(Me.trimCheckBox)
			Me.optionsGruopBox.Controls.Add(Me.flipCheckBox)
			Me.optionsGruopBox.Location = New System.Drawing.Point(138, 12)
			Me.optionsGruopBox.Name = "optionsGroupBox"
			Me.optionsGruopBox.Size = New System.Drawing.Size(76, 71)
			Me.optionsGruopBox.TabIndex = 8
			Me.optionsGruopBox.TabStop = False
			Me.optionsGruopBox.Text = "Options"
			' 
			' TangentsForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(226, 162)
			Me.Controls.Add(Me.optionsGruopBox)
			Me.Controls.Add(Me.curveTypeGroupBox)
			Me.Controls.Add(Me.selectButton)
			Me.Controls.Add(Me.radiusLabel)
			Me.Controls.Add(Me.radiusTextBox)
			Me.Name = "TangentsForm"
			Me.Text = "Tan. curves"
			Me.curveTypeGroupBox.ResumeLayout(False)
			Me.curveTypeGroupBox.PerformLayout()
			Me.optionsGruopBox.ResumeLayout(False)
			Me.optionsGruopBox.PerformLayout()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private WithEvents lineRadioButton As System.Windows.Forms.RadioButton
		Private WithEvents circlesRadioButton As System.Windows.Forms.RadioButton
		Private WithEvents flipCheckBox As System.Windows.Forms.CheckBox
		Private WithEvents trimCheckBox As System.Windows.Forms.CheckBox
		Private WithEvents radiusTextBox As System.Windows.Forms.TextBox
		Private radiusLabel As System.Windows.Forms.Label
		Private WithEvents selectButton As System.Windows.Forms.Button
		Private curveTypeGroupBox As System.Windows.Forms.GroupBox
		Private optionsGruopBox As System.Windows.Forms.GroupBox
	End Class
