
    Partial Public Class DetailsForm
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
			Me.contentTextBox = New System.Windows.Forms.TextBox()
			Me.closeButton = New System.Windows.Forms.Button()
			Me.copyToClipboardButton = New System.Windows.Forms.Button()
			Me.SuspendLayout()
			' 
			' contentTextBox
			' 
			Me.contentTextBox.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.contentTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.contentTextBox.Font = New System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.contentTextBox.Location = New System.Drawing.Point(12, 12)
			Me.contentTextBox.Multiline = True
			Me.contentTextBox.Name = "contentTextBox"
			Me.contentTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
			Me.contentTextBox.Size = New System.Drawing.Size(280, 259)
			Me.contentTextBox.TabIndex = 1
			Me.contentTextBox.WordWrap = False
			' 
			' closeButton
			' 
			Me.closeButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.closeButton.Location = New System.Drawing.Point(217, 277)
			Me.closeButton.Name = "closeButton"
			Me.closeButton.Size = New System.Drawing.Size(75, 23)
			Me.closeButton.TabIndex = 0
			Me.closeButton.Text = "Close"
			Me.closeButton.UseVisualStyleBackColor = True

			' 
			' copyToClipboardButton
			' 
			Me.copyToClipboardButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.copyToClipboardButton.Location = New System.Drawing.Point(136, 277)
			Me.copyToClipboardButton.Name = "copyToClipboardButton"
			Me.copyToClipboardButton.Size = New System.Drawing.Size(75, 23)
			Me.copyToClipboardButton.TabIndex = 3
			Me.copyToClipboardButton.Text = "Copy"
			Me.copyToClipboardButton.UseVisualStyleBackColor = True

			' 
			' DetailsForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(304, 312)
			Me.Controls.Add(Me.copyToClipboardButton)
			Me.Controls.Add(Me.closeButton)
			Me.Controls.Add(Me.contentTextBox)
			Me.Name = "DetailsForm"
			Me.Text = "Details"
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Public contentTextBox As System.Windows.Forms.TextBox
		Private WithEvents closeButton As System.Windows.Forms.Button
		Private WithEvents copyToClipboardButton As System.Windows.Forms.Button
	End Class
