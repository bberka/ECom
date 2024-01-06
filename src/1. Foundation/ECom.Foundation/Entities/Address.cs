using ECom.Foundation.Static;

namespace ECom.Foundation.Entities;

[Table("Addresses", Schema = "ECPrivate")]
public class Address : IEntity
{
  [Key]
  public Guid Id { get; set; }

  public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
  public DateTime? UpdateDate { get; set; }
  public DateTime? DeleteDate { get; set; }

  [MinLength(StaticValues.MIN_NAME_LENGTH)]
  [MaxLength(StaticValues.MAX_NAME_LENGTH)]
  public string Name { get; set; }

  [MinLength(StaticValues.MIN_NAME_LENGTH)]
  [MaxLength(StaticValues.MAX_NAME_LENGTH)]
  public string Surname { get; set; }

  [MaxLength(StaticValues.MAX_TITLE_LENGTH)]
  public string Title { get; set; }

  [MaxLength(StaticValues.MAX_CITY_LENGTH)]
  [MinLength(StaticValues.MIN_CITY_LENGTH)]
  public string Town { get; set; }

  [MaxLength(StaticValues.MAX_COUNTRY_LENGTH)]
  [MinLength(StaticValues.MIN_COUNTRY_LENGTH)]
  public string Country { get; set; }

  [MaxLength(StaticValues.MAX_CITY_LENGTH)]
  [MinLength(StaticValues.MIN_CITY_LENGTH)]
  public string Provience { get; set; }

  [MaxLength(StaticValues.MAX_ADDRESS_LENGTH)]
  [MinLength(StaticValues.MIN_ADDRESS_LENGTH)]
  public string Details { get; set; }

  [MinLength(StaticValues.MIN_PHONE_LENGTH)]
  [MaxLength(StaticValues.MAX_PHONE_LENGTH)]
  public string PhoneNumber { get; set; }

  //FK
  public Guid UserId { get; set; }
}