
using System.Windows;

namespace IPConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //click event for octet to binary Convert button
        private void OctToBinSubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            //if input is valid
            if (LibraryClass.OctetIPValidation(firstOctetTBox.Text, secondOctetTBox.Text,
                thirdOctetTBox.Text, fourthOctetTBox.Text) == true)
            {
                //passes the octet values to the TransformToBinary method in the LibraryClass
                //and populates the binary respective textblocks with the results
                firstBinaryTBlock.Text = LibraryClass.TransformToBinary(firstOctetTBox.Text);
                secondBinaryTBlock.Text = LibraryClass.TransformToBinary(secondOctetTBox.Text);
                thirdBinaryTBlock.Text = LibraryClass.TransformToBinary(thirdOctetTBox.Text);
                fourthBinaryTBlock.Text = LibraryClass.TransformToBinary(fourthOctetTBox.Text);
            }
            //displays a dialiog box when input is invalid
            else
            {
                MessageBox.Show("Not a valid IP address!");
            }

        }

        //click event for octet to binary Copy button
        private void CopyBinaryBtn_Click(object sender, RoutedEventArgs e)
        {
            //if binary textblocks have values
            if (firstBinaryTBlock.Text.Length != 0 && secondBinaryTBlock.Text.Length != 0 &&
                thirdBinaryTBlock.Text.Length != 0 && fourthBinaryTBlock.Text.Length != 0)
            {
                //concatenates a string containing the binary IP address and copies its value to clipboard
                Clipboard.SetText(firstBinaryTBlock.Text + "." + secondBinaryTBlock.Text + "." +
                    thirdBinaryTBlock.Text + "." + fourthBinaryTBlock.Text);
            }
        }

        //click event for binary to octet Convert button (method functions the same as OctToBinSubmitBtn_Click)
        private void BinToOctSubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LibraryClass.BinaryIPValidation(firstBinaryTBox.Text, secondBinaryTBox.Text,
                thirdBinaryTBox.Text, fourthBinaryTBox.Text) == true)
            {
                firstOctetTBlock.Text = LibraryClass.TransformToOctet(firstBinaryTBox.Text);
                secondOctetTBlock.Text = LibraryClass.TransformToOctet(secondBinaryTBox.Text);
                thirdOctetTBlock.Text = LibraryClass.TransformToOctet(thirdBinaryTBox.Text);
                fourthOctetTBlock.Text = LibraryClass.TransformToOctet(fourthBinaryTBox.Text);
            }
            else
            {
                MessageBox.Show("Not a valid binary IP address");
            }
        }

        //click event for binary to octet Copy button
        private void CopyOctetBtn_Click(object sender, RoutedEventArgs e)
        {
            //if octet textblocks have values
            if (firstOctetTBlock.Text.Length != 0 && secondOctetTBlock.Text.Length != 0 &&
                thirdOctetTBlock.Text.Length != 0 && fourthOctetTBlock.Text.Length != 0)
            {
                //concatenates a string containing the octet IP address and copies its value to clipboard
                Clipboard.SetText(firstOctetTBlock.Text + "." + secondOctetTBlock.Text + "." +
                    thirdOctetTBlock.Text + "." + fourthOctetTBlock.Text);
            }
        }
    }
}
