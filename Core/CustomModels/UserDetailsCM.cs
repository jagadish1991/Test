using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CustomModels
{
    public class UserDetailsCM
    {
        public UserDetailsCM()
    {
        UserDetails = new UD();
    }
    public UD UserDetails { get; set; }
}
public class UD
{
    public int UserID { get; set; }
}
}
