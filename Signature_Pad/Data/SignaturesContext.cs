using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Signature_Pad.Models;

namespace Signature_Pad.Data
{
    public class SignaturesContext : DbContext
    {
        public SignaturesContext (DbContextOptions<SignaturesContext> options)
            : base(options)
        {
        }

        public DbSet<Signature_Pad.Models.Signature> Signature { get; set; } = default!;
    }
}
