using System;

class point3d
{
	public int x;
	public int y;
	public int z;
	public point3d()
	{
		this.x = 0;
		this.y = 0;
		this.z = 0;
	}
	public point3d(int x1, int y1, int z1)
	{
		this.x = x1;
		this.y = y1;
		this.z = z1;
	}
	public point3d(decimal x1)
	{
		int j = 1;
		this.x = (int) x1;
		int y = 0;
		int rem = (int)x1 - x1;
		while (rem >= 0)
        {
			rem = rem*10 - (int)(rem*10);
			j++;	
        }
		x1 *= (decimal)Math.Pow(10, j);
		this.y = (int)x1;
		this.z = 0;
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
	public string len_rad_vec()
	{
		return $"Длина радиус-вектора, считая от начала координат {Math.Sqrt(x * x + y * y + z * z)}";
	}
	public string showpos()
	{
		return $"Объект  находитесь на координатах: x: {x} y:{y} z:{z}";
	}
	public int X
	{
		set
		{
			if (value > 0)
			{
				x = value;
			}
			else
			{
				Console.WriteLine("Х должен принимать положительные значения ");
			}
		}
	}
	public int Y
	{
		set
		{
			if (value > 0 && value <= 100)
			{
				y = value;
			}
			else if (value > 0 && value > 100)
			{
				y = 100;
			}
			else
			{
				Console.WriteLine("Y должен принимать положительные значения, максимум - 100 ");
			}
		}
	}
	public int Z
	{
		set
		{
			if (value <= x+y )
			{
				z = value;
			}
			else
			{
				Console.WriteLine($"Z должен принимать значения, меньшие чем сумма двумерных координат, в нашем случае это {x+y} ");
			}
		}
	}
	public bool inzone
    {
		get
        {
			if (x <= 10)
            {
				if (y >= 2)
                {
					if (x <= y) { return true;  }
                }
            }
			return false;
        }
    }
    public  point3d point (point3d point){
		point3d point3;
		int x = point.x + this.x;
		int y = point.y + this.y;
		int z = point.z + this.z;
		point3 = new point3d(x,y,z);
		return point3;
		}
	public void point(int xp, int yp, int zp){
		this.x += xp;
		this.y += yp;
		this.z += zp;
		
		}
	public void point(int par){
		
		this.x += par;
		this.y += par;
		this.z += par;
		}
}
class Program
{


	public static void Main()
	{
		int a;
		Console.WriteLine("Введите 0, если хотите создать объект в нулевых координатах, 1, если хотите указать х и у, и любое другое число , чтобы ввести конкретные координаты");
		a = int.Parse(Console.ReadLine());
		point3d pos1;
		if (a == 0)
		{
			pos1 = new point3d();
		}
		else if (a == 1)
        {
			Console.WriteLine("Введите число с точкой, дробная часть которого равна координатам Y, а целая - X");
			decimal x = decimal.Parse(Console.ReadLine());
			pos1 = new point3d(x);
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
		int req = int.Parse(Console.ReadLine());
		while (req != 0)
		{
			switch (req)
            {
				case 1:
					Console.WriteLine("Введите ось, по которой нужно подвинуть объект");
					char b = Char.Parse(Console.ReadLine());
					while (!"xyz".Contains(b))
						Console.WriteLine("Ось может только: x y или z");
					b = Char.Parse(Console.ReadLine());
					Console.WriteLine("Введите насколько надо подвинуть объект");
					int c = int.Parse(Console.ReadLine());
					pos1.move(b, c);
					break;
				case 2:
					Console.WriteLine(pos1.len_rad_vec());
					break;
				case 3:
					Console.WriteLine("Введите , чему теперь равен Х");
					pos1.X = int.Parse(Console.ReadLine());
					break;
				case 4:
					Console.WriteLine("Введите , чему теперь равен Y");
					pos1.Y = int.Parse(Console.ReadLine());
					break;
				case 5:
					Console.WriteLine("Введите , чему теперь равен Z");
					pos1.Z = int.Parse(Console.ReadLine());
					break;
				case 6:
					if (pos1.inzone)
					Console.WriteLine("Точка находится в зоне, ограниченной треугольником:");
                    else Console.WriteLine("Точка не находится в зоне, ограниченной треугольником:");
					break;

			}
			pos1.showpos();
			req = int.Parse(Console.ReadLine());
			
		}
	}
}
