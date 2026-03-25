using Tmp.Models;
using Tmp.Services;
using Tmp.Services.Logging;

namespace Tmp;

public static class Program {
	public static void Main(string[] args) {
		var logger = new LoggerConsole();
		var userService = new UserService(logger); // poor man's dependency injection
		var deviceService = new DeviceService(logger);
		var leaseService = new LeaseService(logger, userService, deviceService);

		userService.RegisterStudent("Jacek", "Chmielewski", "s2137");
		var userMariuszLagocki = userService.RegisterStudent("Mariusz", "Łagocki", "s0067");
		userService.RegisterStudent("Tadeusz", "Barciński", "s0420");

		userService.RegisterEmployee("Myk", "Bin Saddam");
		var userKoLega = userService.RegisterEmployee("Ko", "Lega");

		deviceService.AddDevice(() => new DeviceLaptop("Apodejrzany Kosmitogramowanie x16 Zorza", DeviceLaptop.OS.Windows, true));
		var deviceMyslBloczek = deviceService.AddDevice(() => new DeviceLaptop("MyślBloczek T490", DeviceLaptop.OS.Linux, false));

		deviceService.AddDevice(() => new DevicePhone("Samsung Galaktyka S30", DevicePhone.OS.Android, 15));
		deviceService.AddDevice(() => new DevicePhone("Samsung Galaktyka Z Złóż 7", DevicePhone.OS.Android, 16));

		var deviceKanoniczny = deviceService.AddDevice(() => new DeviceCamera("Kanoniczny EOS 550D", DeviceCamera.Kind.DSLR));
		deviceService.AddDevice(() => new DeviceCamera("Natychmiastx KWADRAT SQ1", DeviceCamera.Kind.Film));

		leaseService.BeginLease(userMariuszLagocki, deviceKanoniczny, new DateTime(2026, 02, 14), new DateTime(2026, 02, 16));
		leaseService.BeginLease(userMariuszLagocki, deviceKanoniczny, new DateTime(2026, 02, 15), new DateTime(2026, 02, 19));
	}
}
