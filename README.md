# QuinticHermiteSpline
Quintic (not cubic) Hermite spline that adds acceleration control on endpoints.
# Why?
Usually you use [cubic Hermite spline](https://en.wikipedia.org/wiki/Cubic_Hermite_spline) when you want to interpolate between two points, but you can only specify position and velocity per point. Quintic interpolation allows you to set acceleration at both points. It gives more control and is kinda intuitive to use(more on that below).
# How?
[Read me first](https://en.wikipedia.org/wiki/Cubic_Hermite_spline#Representations)
I derived these Hermite basis functions for degree 5 so you can specify acceleration. Summation stays the same. You could derive septic hermite spline so you can specify [jerk](https://en.wikipedia.org/wiki/Jerk_(physics)) but it's probably the first time you see that word used to describe thrid derivative of position, so it doesn't really maek sense to do so. 
