using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Plugin.Calendar.Models;
using XamarinCalendarExemplo.Models;

namespace XamarinCalendarExemplo.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public EventCollection Events { get; set; }

        private CultureInfo _culture = CultureInfo.InvariantCulture;
        public CultureInfo Culture
        {
            get => _culture;
            set => SetProperty(ref _culture, value);
        }

        private void CarregarEventos()
        {
            Culture = CultureInfo.CreateSpecificCulture("pt-BR");

            Events = new EventCollection
            {
                [DateTime.Now] = new List<Evento>
                {
                    new Evento { Nome = "Ajuda", Descricao = "Levar o Milton Cortar o Cabelo" },
                    new Evento { Nome = "Artigos", Descricao = "Escrever Artigo de Calendario" }
                },
                [DateTime.Now.AddDays(5)] = new List<Evento>
                {
                    new Evento { Nome = "Tweet", Descricao = "Postar Algo no Twitter estilo bloguerinho" },
                    new Evento { Nome = "Facebook", Descricao = "Postar Foto de Comida no Facebook" }
                },
                [DateTime.Now.AddDays(-3)] = new List<Evento>
                {
                    new Evento { Nome = "Dentista", Descricao = "Manutenção na Dentadura" }
                },
                [new DateTime(2020, 5, 19)] = new List<Evento>
                {
                    new Evento { Nome = "Microsoft Build", Descricao = "Vai Começar o Build" }
                }
            };
        }

        public MainViewModel()
        {
            CarregarEventos();
        }
    }
}
