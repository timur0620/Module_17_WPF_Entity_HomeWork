//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApp1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Client
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string NumberPhone { get; set; }
        public string Email { get; set; }
        public override string ToString()
        {
            return $"{Id, 3} | {LastName, 10} | {Name,10} | {Surname,20} | {NumberPhone,20} | {Email, 20}";
        }
    }
}
