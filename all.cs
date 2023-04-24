using System; 
class point3d
{
	public int x;
	public int y;
	public int z;
	public point3d()
	{
		this.x = 5;
		this.y = 0;
		this.z = 4;
	}
	point3d(int x1, int y1, int z1)
	{
		this.x = x1;
		this.y = y1;
		this.z = z1;
	}
	static void point3d_dec(decimal x1, out int x, out int y, out int z)
	{
		int j = -1; // счетчик степени десятки
		x = (int)x1; // х - целая часть ее мы получаем , преобразовывая дробное число в целое
		y = 0;
		decimal rem = x1 - (int)x1; // находим дробную часть
		while (rem > 0) // дальше находим длину дробной части, перекидывая каждое число из дробной части в целое и отрезая его
		{
			rem *= 10;
			rem %= 10;
			j++;
		}
		y = (int)((x1 - (int)x1) * (int)Math.Pow(10, j));  // а дальше умножаем дробную часть на 10 в степени длины дробной части
		z = 0;
	}
	public static point3d cool_class(int x2, int y1, int z1, bool dec = false, decimal x1=0.0m)
	{
		point3d point;
		bool end = false;
		int x;
		int y;
		int z;
		if (dec)
        {
			point3d.point3d_dec(x1, out x, out y, out z);
        }
        else
        {
			x = x2;
			y = y1;
			z = z1; 
		}
		try
		{
			if (x % 5 == 0 || y % 5 == 0 || z % 5 == 0)
			{
				if (x > 0)
				{
					if (x + y > z)
					{
						
						return new point3d(x, y, z);
						end = true;
					}
				}
			}
			if (!end) throw new Exception(@"Неверные значения");
		}
		catch (Exception er)
		{
			Console.WriteLine("Класс можно создать только если хоть одна из координат делится на 5, координат х положительна, а координат z не превосходит в сумме х и y");
			Console.WriteLine("Создаю класс по умолчанию");
			
		}
		return new point3d();
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
		return $"Длина радиус-вектора, считая от начала координат {Math.Round(Math.Sqrt(x * x + y * y + z * z), 4)}";
	}
	public string showpos(point3d obj)
	{
		return $"Объект  находитесь на координатах: x: {obj.x} y:{obj.y} z:{obj.z}";
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
			if (value <= x + y)
			{
				z = value;
			}
			else
			{
				Console.WriteLine($"Z должен принимать значения, меньшие чем сумма двумерных координат, в нашем случае это {x + y} ");
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
					if (x <= y) { return true; }
				}
			}
			return false;
		}
	}
	public point3d point_move(point3d point) // сложение координат той точки с которой работаем + координат точки которую передают в кач. параметра в координаты новой 
	{
		point3d newpoint;
		int x_new = x + point.x;
		int y_new = y + point.y;
		int z_new = z + point.z;
		newpoint = new point3d(x_new, y_new, z_new);
		return newpoint;
	}
	public void point_move(int xp, int yp, int zp)
	{
		this.x += xp;
		this.y += yp;
		this.z += zp;
	}
	public void point_move(int param)
	{
		this.x += param;
		this.y += param;
		this.z += param;

	}
}
class Program
{


	public static void Main()
	{
		int a;
		Console.WriteLine("Введите 0, если хотите создать объект в нулевых координатах, 1, если хотите указать х и у с помощью дробного числа, и любое другое число , чтобы ввести конкретные координаты каждой из осей");
		a = int.Parse(Console.ReadLine());
		point3d pos2 = point3d.cool_class(1, 5, 87); // создаем точки для "корма" ( последние перегруженные метода третьей части практики)
		point3d pos3 = point3d.cool_class(4, 6, -15);
		point3d pos1;
		if (a == 0)
		{
			pos1 = new point3d();
		}
		else if (a == 1)
		{
			Console.WriteLine("Введите число с точкой, дробная часть которого равна координатам Y, а целая - X");
			string x = Console.ReadLine();
			if (decimal.TryParse(x, out decimal number))
				pos1 = point3d.cool_class(0, 0, 0, true, number);
            else
            {
				Console.WriteLine("Создаю класс по умолчанию");
				pos1 = point3d.cool_class(-7, 0, 0, true, number); // заведомо вызовется класс по умолчанию 
			}
		}
		else
		{
			Console.Write("Введите координаты по оси х");
			int x1 = int.Parse(Console.ReadLine());
			Console.Write("\n Введите координаты по оси y");
			int y1 = int.Parse(Console.ReadLine());
			Console.Write("\n Введите координаты по оси z");
			int z1 = int.Parse(Console.ReadLine());
			pos1 = point3d.cool_class(x1, y1, z1);
		}
		Console.WriteLine("СПИСОК КОМАНД:");
		Console.WriteLine("0 если хотите подвинуть закончить работу с программой");
		Console.WriteLine("1 если хотите подвинуть объект по конкретной оси");
		Console.WriteLine("2 если хотите найти длину радиус вектора");
		Console.WriteLine("3 если хотите пометь значение Х");
		Console.WriteLine("4 если хотите пометь значение У");
		Console.WriteLine("5 если хотите пометь значение Z");
		Console.WriteLine("6 если хотите проверить, находится ли точка в закрашенной зоне");
		Console.WriteLine("7 если хотите создать точку из суммы двух других");
		Console.WriteLine("8 если хотите изменить кординаты точки на координаты другой");
		Console.WriteLine("9 если хотите подвинуть объект по всем осям на конкретное значение");
		Console.WriteLine("_________________________");

		int req = int.Parse(Console.ReadLine());
		while (req != 0)
		{
			Console.WriteLine(pos1.showpos(pos1));
			switch (req)
			{
				case 1:
					Console.WriteLine("Введите ось, по которой нужно подвинуть объект");
					char b = Char.Parse(Console.ReadLine());
					while (!"xyz".Contains(b))
						Console.WriteLine("Ось может только: x y или z");
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
						Console.WriteLine("Точка находится в зоне, ограниченной треугольником");
					else Console.WriteLine("Точка не находится в зоне, ограниченной треугольником");
					break;
				case 7:
					Console.WriteLine("Создана новая точка с координатами равными сумме координат двух других");
					point3d point4 = pos1.point_move(pos2);
					Console.WriteLine("Ее координаты равны" + pos1.showpos(point4));

					break;
				case 8:
					Console.WriteLine("Координаты точки, на которые мы будем сдвигать:");
					Console.WriteLine(pos1.showpos(pos3));

					Console.WriteLine("Точка подвинута на координаты другой точки");

					pos1.point_move(pos3.x, pos3.y, pos3.z);
					break;
				case 9:
					Console.WriteLine("Введите параметр, на который увеличатся все координаты");
					int par = int.Parse(Console.ReadLine());
					pos1.point_move(par);
					break;
				case 0:
					break;
				default:
					Console.WriteLine("НЕИЗВЕСТНАЯ КОМАНДА");
					break;

			}
			Console.WriteLine("_________________________");
			Console.WriteLine(pos1.showpos(pos1));
			Console.WriteLine("_________________________");

			Console.Write("Введите команду:");
			req = int.Parse(Console.ReadLine());




		}
	}
}
