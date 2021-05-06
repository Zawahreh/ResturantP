namespace storev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedMeals : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Meals (name, price, category, photo) VALUES( 'Margarita Pizza', 3.75, 'Pizza', 'Margarita2_big.jpg'),('Chicken Alfredo Pizza', 5.99, 'Pizza', 'Chicken Alfredo2_big.jpg'),('Pepperoni Lovers Pizza', 4.74, 'Pizza', 'Pepperoni lovers2_big.jpg'),('Philly Steak Sandwich', 2.54, 'Sandwich', 'Philly steak sandwich2_big.jpg'),( 'Chicken Sandwich', 2.37, 'Sandwich', 'Chicken sandwich2_big.jpg'),('Hotdog Sandwich', 2.15, 'Sandwich', 'hotdog sandwich2_big.jpg'),('Turkey Sandwich', 2.37, 'Sandwich', 'turkey sandwich2_big.jpg'),('Caesar Salad', 3.01, 'Salad', 'Caesar salad2_big.jpg'),('Greek Salad', 2.37, 'Salad', 'Greek salad2_big.jpg'),('Arabic Salad', 1.94, 'Salad', 'Arabic salad2_big.jpg'),('Tuna Salad', 2.59, 'Salad', 'Tuna salad2_big.jpg'),('Pepsi', 0.52, 'Beverages', 'Pepsi-min_636021950800177962.jpg'),('Diet Pepsi', 0.52, 'Beverages', 'Diet_Pepsi_big.jpg'),('Mountain Dew', 0.52, 'Beverages', 'mtnDew_big.jpg'),( 'Mineral Water (Small)', 0.26, 'Beverages', 'Water-min_636021951390013962.jpg'),( 'Boneless Wings', 3.02, 'Extra', 'bonless wing_big.jpg'),( 'French Fries', 0.86, 'Extra', 'french fries2_big.jpg'),( 'Potato Wedges', 1.29, 'Extra', 'wedges2_big.jpg'),( 'Sauces', 0.43, 'Extra', 'Dip_big.jpg'); ");
        }

        public override void Down()
        {
        }
    }
}
