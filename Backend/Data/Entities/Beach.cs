namespace BeachApi.Data.Entities;

public class Beach
{
  public int Id{get;set;}
  public required string BeachName{get;set;}
  public required string Place{get;set;}

  public required string ImageUrl{get;set;}
}
