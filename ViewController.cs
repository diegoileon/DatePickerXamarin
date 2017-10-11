using System;
using CoreGraphics;
using UIKit;

namespace DatePicker
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            UIDatePicker datePicker = new UIDatePicker();

            datePicker.Mode = UIDatePickerMode.Date;

			var toolbar = new UIToolbar(new CGRect(0, 0, UIScreen.MainScreen.Bounds.Width, 44))
			{
				BarStyle = UIBarStyle.Default,
				Translucent = true
			};

			// Set Font to be used in tools
			UIFont font = UIFont.SystemFontOfSize(24);

            fechaTextField.InputView = datePicker;
            fechaTextField.InputAccessoryView = toolbar;
            fechaTextField.Font = font;

			// Now add a Done button to the toolbar to rest text fields
			var spacer = new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace);
			var doneButton = new UIBarButtonItem(UIBarButtonSystemItem.Done, (o, a) =>
			{
                fechaTextField.ResignFirstResponder();
                DateTime dateTime = ((DateTime)datePicker.Date).ToLocalTime();
                fechaTextField.Text = dateTime.ToLongDateString();
			});

			toolbar.SetItems(new[] { spacer, doneButton }, false);


        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
