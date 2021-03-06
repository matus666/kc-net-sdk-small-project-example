// This code was generated by a cloud-generators-net tool 
// (see https://github.com/Kentico/cloud-generators-net).
// 
// Changes to this file may cause incorrect behavior and will be lost if the code is regenerated. 
// For further modifications of the class, create a separate file with the partial class.

using System;
using System.Collections.Generic;
using KenticoCloud.Delivery;

namespace KcNetSdkSmallProjectExample.Models
{
    public partial class Person
    {
        public const string Codename = "person";
        public const string ProfilePhotoCodename = "profile_photo";
        public const string BioCodename = "bio";
        public const string NameAndSurnameCodename = "name_and_surname";
        public const string GenderCodename = "gender";
        public const string FavoriteNumberCodename = "favorite_number";
        public const string UrlSlugCodename = "url_slug";
        public const string DateOfBirthCodename = "date_of_birth";

        public IEnumerable<Asset> ProfilePhoto { get; set; }
        public IRichTextContent Bio { get; set; }
        public string NameAndSurname { get; set; }
        public IEnumerable<MultipleChoiceOption> Gender { get; set; }
        public decimal? FavoriteNumber { get; set; }
        public string UrlSlug { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public ContentItemSystemAttributes System { get; set; }
    }
}