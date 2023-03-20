using System;
class point3d
{
	public int x;
	public int y;
	public int z;
	public point3d()
	{
		x = 0;
		y = 0;
		z = 0;
	}
	public point3d(int x1, int y1, int z1)
	{
		x = x1;
		y = y1;
		z = z1;
	}
	public void move(char axis, int dist)
	{
		if (axis == 'x')
		{
			x += dist;
		}
		if (axis == 'y')
		{
			y += dist;
		}
		if (axis == 'z')
		{
			z += dist;
		}
	}
	public double len_rad_vec()
    {
		Console.WriteLine($"Длина радиус-вектора, считая от начала координат {Math.Sqrt(x*x+y*y+z*z)}");
    }
	public void showpos()
	{
		Console.WriteLine($"Объект  находитесь на координатах: x: {x} y:{y} z:{z}");
	}
}
class Program
{


	public static void Main()
	{
		int a;
		Console.WriteLine("Введите 0, если хотите создать объект в нулевых координатах, и любое другое число , чтобы ввести конкретные координаты");
		a = int.Parse(Console.ReadLine());
		point3d pos1;
		if (a == 0)
			{ 
			pos1 = new point3d(); 
		}
		else
			{
			Console.Write("Введите координаты по оси х");
			int x1 = int.Parse(Console.ReadLine());
			Console.Write("\n Введите координаты по оси y");
			int y1 = int.Parse(Console.ReadLine());
			Console.Write("\n Введите координаты по оси z");
			int z1 = int.Parse(Console.ReadLine());
			pos1 = new point3d(x1, y1, z1); 
		}
		pos1.showpos();
		Console.WriteLine("Введите ось, по которой нужно подвинуть объект");
		char b = Char.Parse(Console.ReadLine());
		while (!"xyz".Contains(b))
			Console.WriteLine("Ось может только: x y или z");
			 b = Char.Parse(Console.ReadLine());
		Console.WriteLine("Введите насколько надо подвинуть объект");
		int c = int.Parse(Console.ReadLine());
		pos1.move(b, c);
		pos1.showpos();
		pos1.len_rad_vec();
	}
}
