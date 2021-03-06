﻿using System;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;


namespace SQLiteSample
{
    public class AddContactViewModel : BaseContactViewModel
    {
        public ICommand AddContactCommand { get; private set; }
        public ICommand ViewAllContactsCommand { get; private set; }
    
        public AddContactViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _contactValidator = new ContactValidator();
            _contact = new ContactInfo();
            _contactRepository = new ContactRepository();

            AddContactCommand = new Command(async () => await AddContact());
            ViewAllContactsCommand = new Command(async () => await ShowContactList());
        }

        async Task AddContact()
        {
            var validationResults = _contactValidator.Validate(_contact);

            if (validationResults.IsValid)
            {
                bool isUserAccept = await Application.Current.MainPage.DisplayAlert("Add Contact", "Do you want to save Contact details?", "OK", "Cancel");
                if (isUserAccept)
                {
                    _contactRepository.InsertContact(_contact);
                    await _navigation.PushAsync(new ContactList());
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Add Contact", validationResults.Errors[0].ErrorMessage, "Ok");
            }
        }

        async Task ShowContactList()
        {
            await _navigation.PushAsync(new ContactList());
        }

        public bool IsViewAll => _contactRepository.GetAllContactsData().Count > 0 ? true : false;
    }
}
