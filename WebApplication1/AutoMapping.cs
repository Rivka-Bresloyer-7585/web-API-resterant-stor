using AutoMapper;
using DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myProject
{
    public class AutoMapping :Profile
    {
        public AutoMapping()
        {
            CreateMap<Orders, OrdersDTO>();
        }
    }
}
