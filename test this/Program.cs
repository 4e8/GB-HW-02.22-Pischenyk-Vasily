static void Main (string[] args)
{

}
private static int GCD(int num, int den)
{
    while (den != 0)
    {
        var t = den;
        den = num % den;
        num = t;
    }
}

private FractionalNumbers SimplificationFractional()
{
    int gcd = GCD(n, d);
    if (gcd > 1)
    {
        n /= gcd;
        d /= gcd;
    }
    return this;
}