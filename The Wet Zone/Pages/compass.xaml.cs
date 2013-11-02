using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using QiblaCompass.ViewModel;
using Microsoft.Devices.Sensors;
using System.Windows.Media;

namespace The_Wet_Zone.Pages
{
    public partial class compass : PhoneApplicationPage
    {
        bool calibratingFlag;
        QiblaViewModel _viewModel;
        bool _isNewPageInstance;
        Compass compassOpt;

        public compass()
        {
            InitializeComponent();
            _isNewPageInstance = true;

        }
        #region Page state events.

        // When navigates to.
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            if (_isNewPageInstance)
            {
                #region Restoring the Page State.
                if (_viewModel == null)
                {
                    if (State.Count > 0)
                    {
                        _viewModel = (QiblaViewModel)State["ViewModel"];
                    }
                    else
                    {
                        _viewModel = new QiblaViewModel();
                        GetQibla();
                    }
                }

                #endregion
            }

        }

        // When navigates away.
        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            if (e.NavigationMode != System.Windows.Navigation.NavigationMode.Back)
            {
                State["ViewModel"] = _viewModel;
            }
            else
            {
                compassOpt.Stop();
            }
        }

        #endregion

        #region Helper Methods to Find Qibla
        private void GetQibla()
        {
            compassOpt = new Compass();
            compassOpt.Calibrate += compass_Calibrate;
            compassOpt.CurrentValueChanged += compass_CurrentValueChanged;
            compassOpt.TimeBetweenUpdates = TimeSpan.FromMilliseconds(20);
            compassOpt.Start();
        }

        void compass_CurrentValueChanged(object sender, SensorReadingEventArgs<CompassReading> e)
        {
            try
            {
                if (compassOpt.IsDataValid)
                {
                    Dispatcher.BeginInvoke(() =>
                    {
                        // To check the calibration's reading.
                        double headingAccuracy = e.SensorReading.HeadingAccuracy;

                        if (!calibratingFlag)
                        {
                            double trueHeading = e.SensorReading.TrueHeading;
                            double qiblaDegrees = _viewModel.GetQiblaAngleInDegrees();
                            RotateTransform roseTransform = new RotateTransform() { Angle = 360 - trueHeading };
                            RotateTransform qiblaTransform = new RotateTransform() { Angle = roseTransform.Angle + qiblaDegrees };

                            // Assigning the respective values to rose and qibla transform controls.
                            CompassFace.RenderTransformOrigin = new Point(0.5, 0.5);
                            QiblaControl.RenderTransformOrigin = new Point(0.5, 0.5);
                            CompassFace.RenderTransform = roseTransform;
                            QiblaControl.RenderTransform = qiblaTransform;


                        }
                        else
                        {
                            // For Calibration StackPanel.
                            if (headingAccuracy <= 10)
                            {
                                calibrationTextBlock.Foreground = new SolidColorBrush(Colors.Green);
                                calibrationTextBlock.Text = "Complete!";
                            }
                            else
                            {
                                calibrationTextBlock.Foreground = new SolidColorBrush(Colors.Red);
                                calibrationTextBlock.Text = headingAccuracy.ToString("0.0");
                            }
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK);
            }
        }

        void compass_Calibrate(object sender, CalibrationEventArgs e)
        {
            try
            {
                Dispatcher.BeginInvoke(() => { calibrationStackPanel.Visibility = Visibility.Visible; });
                calibratingFlag = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK);
            }
        }
        #endregion

        #region Calibration of a Compass
        private void calibrationDone_Click(object sender, RoutedEventArgs e)
        {
            calibrationStackPanel.Visibility = System.Windows.Visibility.Collapsed;
            calibratingFlag = false;
        }
        #endregion

        #region AppBar Helper Methods
        private void QiblaDirection_PinToStart(object sender, EventArgs e)
        {
            // Look to see if the tile already exists and if so, don't try to create again.
            var TileToFind = ShellTile.ActiveTiles.FirstOrDefault();

            // Create the tile if we didn't find it already exists.
            if (TileToFind == null)
            {
                // Create the tile object and set some initial properties for the tile.
                // The Count value of 12 will show the number 12 on the front of the Tile. Valid values are 1-99.
                // A Count value of 0 will indicate that the Count should not be displayed.
                FlipTileData QiblaTileData = new FlipTileData
                {
                    // BackContent, BackTitle, WideBackContent, BackBackgroundImage
                    BackTitle = "Qibla",
                    BackContent = "Tap for Qibla",
                    WideBackContent = "Tap to get direction of Qibla"

                };

                // Create the tile and pin it to Start. This will cause a navigation to Start and a deactivation of our application.
                ShellTile.Create(new Uri("/View/QiblaDirection.xaml?DefaultTitle=QiblaDirection", UriKind.Relative), QiblaTileData, true);
            }
        }
        #endregion
    }
}