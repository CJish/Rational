namespace Program
{
    public class Rational
    {
        public int numerator, denominator;

        // default constructor
        public Rational()
        {
            this.numerator = 0;
            this.denominator = 1;
        }

        public Rational(int num, int denom)
        {
            this.numerator = num;
            this.denominator = denom;
        }

        public string WriteRational()
        {
            string returnString = "numerator: " + numerator + "\tdenominator: " + denominator;

            return returnString;
        }

        public void Negate()
        {
            numerator = numerator * (-1);
            denominator = denominator * (-1);
        }

        public void Invert()
        {
            int temp;
            temp = denominator;
            denominator = numerator;
            numerator = temp;
        }

        public double ToDouble()
        {
            double result;

            result = Convert.ToDouble(numerator) / Convert.ToDouble(denominator);

            return result;
        }

        public int Reduce()
        {
            int a, b, temp;
            a = Math.Abs(numerator);
            b = Math.Abs(denominator);
            // gcd(36, 20) = gcd(20, 16) = gcd(16, 4) = gcd(4, 0) = 4

            while (b != 0)
            {
                temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }

        public static string Add(Rational r1, Rational r2) // static method
        {
            string returnString;
            int GCD;

            Rational newRational = new Rational();

            newRational.numerator = r1.numerator + r2.numerator;
            newRational.denominator = r1.denominator + r2.denominator;

            GCD = newRational.Reduce();

            newRational.numerator = newRational.numerator / GCD;
            newRational.denominator = newRational.denominator / GCD;

            returnString = "numerator: " + newRational.numerator + "\tdenominator: " + newRational.denominator;

            return returnString;
        }

        public string Add2(Rational r2) // instance method
        {
            string returnString;
            int GCD;

            Rational newRational = new Rational();

            newRational.numerator = this.numerator + r2.numerator;
            newRational.denominator = this.denominator + r2.denominator;

            GCD = newRational.Reduce();

            newRational.numerator = (newRational.numerator / GCD);
            newRational.denominator = (newRational.denominator / GCD);

            returnString = "numerator: " + newRational.numerator + "\tdenominator: " + newRational.denominator;

            return returnString;
        }

        public static void Main(string[] args)
        {
            Rational rational1 = new Rational();
            Rational rational2 = new Rational(21, 35);

            rational1.numerator = 20;
            rational1.denominator = 36;

            Console.WriteLine(rational1.WriteRational());

            rational1.Negate();
            Console.WriteLine(rational1.WriteRational());

            rational1.Invert();
            Console.WriteLine(rational1.WriteRational());

            rational1.ToDouble();
            Console.WriteLine(rational1.ToDouble());

            Console.WriteLine(rational1.Reduce());

            Console.WriteLine(Rational.Add(rational1, rational2));
            Console.WriteLine(rational1.Add2(rational2));
        }
    }
}
