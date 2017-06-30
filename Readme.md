# .NET SDK - Carable wrapper to Assembly Payment API

[![NuGet version](https://badge.fury.io/nu/carable%2Fcarable.assemblypayments.svg)](http://badge.fury.io/nu/carable%2Fcarable.assemblypayments) [![Build Status](https://travis-ci.org/carable/carable.assemblypayments.svg)](https://travis-ci.org/carable/carable.assemblypayments) [![Code Climate](https://codeclimate.com/github/carable/carable.assemblypayments/badges/gpa.svg)](https://codeclimate.com/github/carable/carable.assemblypayments) 

# 1. Installation

**NuGet:** Install Assembly Payment via NuGet package manager. The package name is '[Carable.AssemblyPayments](https://www.nuget.org/packages/Carable.AssemblyPayments)'.

**Source:** Download latest sources from GitHub, add project into your solution and build it.


# 2. Configuration

Before interacting with Assembly Payment API, you need to generate an API token. See [http://docs.promisepay.com/v2.2/docs/request_token](http://docs.promisepay.com/v2.2/docs/request_token) for more information.

Once you have recorded your API token, configure the .NET package.

**Environments**

	Prelive: https://test.api.promisepay.com
	Production: https://secure.api.promisepay.com

**Final configuration**

Carable wrapper of Assembly Payment API package is build using Dependency Injection principle. It makes integration into your application easy and seamless. It uses the [Microsoft.Extensions.DependencyInjection.Abstractions](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection.Abstractions/) to abstract the dependency injection.

You will need to setup your DI container to bind interfaces and implementations of the package together.

```
services.AddAssemblyPayment()
```

Before that you need to configure how the settings are fetched:

```
services.Configure<AssemblyPaymentSettings>(Configuration.GetSection("AssemblyPaymentSettings"));
```

Then, you can use repositories from package, by resolving interface with container, or passing dependencies into constructor.


# 3. Contributing

	1. Fork it ( https://github.com/carable/carable.assemblypayments/fork )
	2. Create your feature branch (`git checkout -b my-new-feature`)
	3. Commit your changes (`git commit -am 'Add some feature'`)
	4. Push to the branch (`git push origin my-new-feature`)
	5. Create a new Pull Request
