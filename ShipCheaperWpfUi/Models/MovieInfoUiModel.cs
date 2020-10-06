using Catel.Data;
using Catel.MVVM;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ShipCheaperWpfUi.Models
{
    public class MovieInfoUiModel : ValidatableModelBase
    {

        [Model]
        public string ImdbId
        {
            get { return GetValue<string>(ImdbIdProperty); }
            private set { SetValue(ImdbIdProperty, value); }
        }

        public static readonly PropertyData ImdbIdProperty = RegisterProperty(nameof(ImdbId), typeof(string));

        [Model]
        public string TitleOfMovie
        {
            get { return GetValue<string>(TitleProperty); }
            private set { SetValue(TitleProperty, value); }
        }

        public static readonly PropertyData TitleProperty = RegisterProperty(nameof(TitleOfMovie), typeof(string));


        [Model]
        public string Runtime
        {
            get { return GetValue<string>(RuntimeProperty); }
            private set { SetValue(RuntimeProperty, value); }
        }

        public static readonly PropertyData RuntimeProperty = RegisterProperty(nameof(Runtime), typeof(string));


        [Model]
        public string Year
        {
            get { return GetValue<string>(YearProperty); }
            private set { SetValue(YearProperty, value); }
        }

        public static readonly PropertyData YearProperty = RegisterProperty(nameof(Year), typeof(string));

        [Model]
        public string Poster
        {
            get { return GetValue<string>(PosterProperty); }
            private set { SetValue(PosterProperty, value); }
        }

        public static readonly PropertyData PosterProperty = RegisterProperty(nameof(Poster), typeof(string));


        [Model]
        public string Genre
        {
            get { return GetValue<string>(GenreProperty); }
            private set { SetValue(GenreProperty, value); }
        }

        public static readonly PropertyData GenreProperty = RegisterProperty(nameof(Genre), typeof(string));


        [Model]
        public string Writer
        {
            get { return GetValue<string>(WriterProperty); }
            private set { SetValue(WriterProperty, value); }
        }

        public static readonly PropertyData WriterProperty = RegisterProperty(nameof(Writer), typeof(string));


        public bool IsFavorite
        {
            get => GetValue<bool>(IsFavoriteProperty);
            set => SetValue(IsFavoriteProperty, value);
        }

        public static readonly PropertyData IsFavoriteProperty = RegisterProperty(nameof(IsFavorite), typeof(bool), null);
    }
}
