using System.Windows;

namespace KarmaClient
{
    /// <summary>
    /// Interaction logic for ModifyAddNewItemsWindow.xaml
    /// </summary>
    public  partial class ModifyAddNewItemsWindow : Window
    {
        public static ProductServiceRef.ProductServicesClient proxyProducts = new ProductServiceRef.ProductServicesClient();
        ProductServiceRef.Product productToAdd;
      
        // List<ProductServiceRef.Product> productAdded;
        public ModifyAddNewItemsWindow()
        {
            InitializeComponent();
            PopulateListBox();
            


        }

        public void PopulateListBox()
        {
            ProductServiceRef.Product[] products= proxyProducts.GetAllProducts();

            ProductsList.ItemsSource = null;
            ProductsList.ItemsSource = products;
        }
        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    //ProductServiceRef.Product selectedProduct = ProductsList.SelectedItem;

        //    var smallDel = (Button)sender;
        //    if (smallDel != null)
        //    {
        //        if (smallDel.DataContext is ProductServiceRef.Product product)
        //        {
        //            productToAdd = product;
        //        }
        //    }
        
        //    ModifyOrderWindow.productsIdInOrder.Add(productToAdd);
          
        //    MessageBox.Show(productToAdd.Name);
        //    this.Close();
        //}

        public ProductServiceRef.Product productsReturned()
        {

            return productToAdd;

        }

    }
    }

