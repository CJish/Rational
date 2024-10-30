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

        public string WriteRational(Rational r)
        {
            string returnString = "numerator: " + r.numerator + "\tdenominator: " + r.denominator;

            return returnString;
        }

        public void Negate()
        {
            numerator = numerator * (-1);
            denominator = denominator * (-1);
        }

        public void Invert(Rational r)
        {
            int temp;
            temp = r.denominator;
            r.denominator = r.numerator;
            r.numerator = temp;
        }

        public double ToDouble(Rational r)
        {
            double result;

            result = Convert.ToDouble(r.numerator) / Convert.ToDouble(r.denominator);

            return result;
        }

        public int Reduce(Rational r)
        {
            int a, b, temp;
            a = Math.Abs(r.numerator);
            b = Math.Abs(r.denominator);
            // gcd(36, 20) = gcd(20, 16) = gcd(16, 4) = gcd(4, 0) = 4

            while (b != 0)
            {
                temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }

        public static string Add(Rational r1, Rational r2)
        {
            string returnString;
            int GCD;

            Rational newRational = new Rational();

            newRational.numerator = r1.numerator + r2.numerator;
            newRational.denominator = r1.denominator + r2.denominator;

            GCD = newRational.Reduce(newRational);

            newRational.numerator = newRational.numerator / GCD;
            newRational.denominator = newRational.denominator / GCD;

            returnString = "numerator: " + newRational.numerator + "\tdenominator: " + newRational.denominator;

            return returnString;
        }

        public string Add2(Rational r2)
        {
            string returnString;
            int GCD;

            Rational newRational = new Rational();

            newRational.numerator = this.numerator + r2.numerator;
            newRational.denominator = this.denominator + r2.denominator;

            GCD = newRational.Reduce(newRational);

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

            Console.WriteLine(rational1.WriteRational(rational1));

            rational1.Negate();
            Console.WriteLine(rational1.WriteRational(rational1));

            rational1.Invert(rational1);
            Console.WriteLine(rational1.WriteRational(rational1));

            rational1.ToDouble(rational1);
            Console.WriteLine(rational1.ToDouble(rational1));

            Console.WriteLine(rational1.Reduce(rational1));

            Console.WriteLine(Rational.Add(rational1, rational2));
            Console.WriteLine(rational1.Add2(rational2));
        }
    }
}
