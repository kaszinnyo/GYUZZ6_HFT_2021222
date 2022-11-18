using GYUZZ6_HFT_2021222.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GYUZZ6_HFT_2021222.WpfClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public RestCollection<Car> Cars { get; set; }
        public RestCollection<Brand> Brands { get; set; }
        public RestCollection<Rent> Rents { get; set; }

        private Car selectedCar;

        public Car SelectedCar
        {
            get { return selectedCar; }
            set
            {
                if (value != null)
                {
                    selectedCar = new Car()
                    {
                        Id = value.Id,
                        Model = value.Model,
                        BasePrice = value.BasePrice,
                        BrandId = value.BrandId,
                    };

                }
                OnPropertyChanged();
                (CreateCarCommand as RelayCommand).NotifyCanExecuteChanged();
                (DeleteCarCommand as RelayCommand).NotifyCanExecuteChanged();
                (UpdateCarCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        private Brand selectedBrand;

        public Brand SelectedBrand
        {
            get { return selectedBrand; }
            set
            {
                if (value != null)
                {
                    selectedBrand = new Brand()
                    {
                        Id = value.Id,
                        Name = value.Name,
                    };
                }
                OnPropertyChanged();
                (CreateBrandCommand as RelayCommand).NotifyCanExecuteChanged();
                (DeleteBrandCommand as RelayCommand).NotifyCanExecuteChanged();
                (UpdateBrandCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        private Rent selectedRent;

        public Rent SelectedRent
        {
            get { return selectedRent; }
            set
            {
                if (value != null)
                {
                    selectedRent = new Rent()
                    {
                        Id = value.Id,
                        Date = value.Date,
                        CarId = value.CarId,
                        Rating = value.Rating,
                        RenterName = value.RenterName,
                        RentTime = value.RentTime,
                    };
                }
                OnPropertyChanged();
                (CreateRentCommand as RelayCommand).NotifyCanExecuteChanged();
                (DeleteRentCommand as RelayCommand).NotifyCanExecuteChanged();
                (UpdateRentCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }



        //Car Commands
        public ICommand CreateCarCommand { get; set; }
        public ICommand DeleteCarCommand { get; set; }
        public ICommand UpdateCarCommand { get; set; }

        //Brand Commands
        public ICommand CreateBrandCommand { get; set; }
        public ICommand DeleteBrandCommand { get; set; }
        public ICommand UpdateBrandCommand { get; set; }

        //REnt Commands
        public ICommand CreateRentCommand { get; set; }
        public ICommand DeleteRentCommand { get; set; }
        public ICommand UpdateRentCommand { get; set; }
        public MainWindowViewModel()
        {
            Cars = new RestCollection<Car>("http://localhost:18131/", "car", "hub");
            Brands = new RestCollection<Brand>("http://localhost:18131/", "brand", "hub");
            Rents = new RestCollection<Rent>("http://localhost:18131/", "rent", "hub");

            CreateCarCommand = new RelayCommand(
                () => Cars.Add(new Car()
                {
                    Model = SelectedCar.Model,
                })
                );

            DeleteCarCommand = new RelayCommand(
                () => Cars.Delete(SelectedCar.Id),
                () => SelectedCar != null
                );

            UpdateCarCommand = new RelayCommand(
                () => Cars.Update(SelectedCar),
                () => SelectedCar != null
                );

            CreateBrandCommand = new RelayCommand(
                () => Brands.Add(new Brand
                {
                    Name = SelectedBrand.Name,
                })
                );

            DeleteBrandCommand = new RelayCommand(
                () => Brands.Delete(SelectedBrand.Id),
                () => SelectedBrand != null
                );

            UpdateBrandCommand = new RelayCommand(
                () => Brands.Update(SelectedBrand),
                () => SelectedBrand != null
                );

            CreateRentCommand = new RelayCommand(
                () => Rents.Add(new Rent()
                {
                    Date = SelectedRent.Date,
                    CarId = SelectedRent.CarId,
                    Rating = SelectedRent.Rating,
                    RenterName = SelectedRent.RenterName,
                    RentTime = SelectedRent.RentTime,
                })
                );

            DeleteRentCommand = new RelayCommand(
                () => Rents.Delete(SelectedRent.Id),
                () => SelectedRent != null
                );

            UpdateRentCommand = new RelayCommand(
                () => Rents.Update(SelectedRent),
                () => SelectedRent != null
                );

            SelectedCar = new Car();
            SelectedBrand = new Brand();
            SelectedRent = new Rent();
        }
    }
}
