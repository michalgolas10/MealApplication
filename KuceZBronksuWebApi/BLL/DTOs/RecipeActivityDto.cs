﻿namespace KuceZBronksuWebApi.BLL.DTOs
{
	public class RecipeActivityDto
	{
		public int RecipeId { get; set; }
		public DateTime Date { get; set; }
		public string UserId { get; set; }
		public string RecipeType { get; set; }
	}
}
