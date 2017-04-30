using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace HAPExplorer.Properties {
    
    
    // This class allows you to handle specific events on the settings class:
    //  The SettingChanging event is raised before a setting's value is changed.
    //  The PropertyChanged event is raised after a setting's value is changed.
    //  The SettingsLoaded event is raised after the setting values are loaded.
    //  The SettingsSaving event is raised before the setting values are saved.
    internal sealed partial class Settings {
        private ObservableCollection<string> _urlHistoryItems;
        public ObservableCollection<string> UrlHistoryItems
        {
            get
            {
                if(_urlHistoryItems==null)
                {
                    _urlHistoryItems =
                        new ObservableCollection<string>(UrlHistory.Split(new[] {"||"},
                                                                          System.StringSplitOptions.RemoveEmptyEntries));
                    _urlHistoryItems.CollectionChanged += UrlHistoryItemsCollectionChanged;
                }
                return _urlHistoryItems;
            }
        }

        void UrlHistoryItemsCollectionChanged(object sender,NotifyCollectionChangedEventArgs e)
        {
            UrlHistory = string.Join("||", _urlHistoryItems.ToArray());
            Save();
        }
        public Settings() {
            // // To add event handlers for saving and changing settings, uncomment the lines below:
            //
            // this.SettingChanging += this.SettingChangingEventHandler;
            //
            // this.SettingsSaving += this.SettingsSavingEventHandler;
            //
        }
        
        private void SettingChangingEventHandler(object sender, System.Configuration.SettingChangingEventArgs e) {
            // Add code to handle the SettingChangingEvent event here.
        }
        
        private void SettingsSavingEventHandler(object sender, System.ComponentModel.CancelEventArgs e) {
            // Add code to handle the SettingsSaving event here.
        }
    }
}
