﻿using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    internal class UserProfileMap:BaseMap<UserProfile>
    {
        public UserProfileMap() 
        {
            ToTable("Kullanıcı Profilleri");
            Property(x => x.FirstName).HasColumnName("İsim");
        }
    }
}
