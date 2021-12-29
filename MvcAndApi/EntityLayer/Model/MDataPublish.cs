using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace EntityLayer.Model
{
    [DataContract]
    public class MDataPublish
    {
        [Key]
        public int DataPublishID { get; set; }
        public string SensorName { get; set; }
        public string DataName { get; set; }
        public string DataValue { get; set; }
        public DateTime PublishDateTime { get; set; }
    }
    public class MDataPublishConfiguration : IEntityTypeConfiguration<MDataPublish>
    {
        public void Configure(EntityTypeBuilder<MDataPublish> builder)
        {
            builder.HasKey(user => user.DataPublishID);
        }
    }
}
