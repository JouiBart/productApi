using Product.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.MigrationService
{
    internal static class ProductSeedData
    {

        public static List<Infrastructure.Models.PRO_Product> GetProducts()
        {
            return new List<Infrastructure.Models.PRO_Product>
            {
                new Infrastructure.Models.PRO_Product
                {
                    ProductName = "Wireless Mouse",
                    ImageUrl = "https://example.com/images/wireless-mouse.jpg",
                    Price = 499.99m,
                    DescriptionOfProduct = "A comfortable wireless mouse with ergonomic design and long battery life.",
                    QuatityStock = 150
                },
                new Infrastructure.Models.PRO_Product
                {
                    ProductName = "Mechanical Keyboard",
                    ImageUrl = "https://example.com/images/mechanical-keyboard.jpg",
                    Price = 1599.00m,
                    DescriptionOfProduct = "RGB backlit mechanical keyboard with blue switches and detachable wrist rest.",
                    QuatityStock = 80
                },
                new Infrastructure.Models.PRO_Product
                {
                    ProductName = "27\" 4K Monitor",
                    ImageUrl = "https://example.com/images/4k-monitor.jpg",
                    Price = 7999.00m,
                    DescriptionOfProduct = "Ultra HD 4K monitor with IPS panel and adjustable stand.",
                    QuatityStock = 40
                },
                new Infrastructure.Models.PRO_Product
                {
                    ProductName = "USB-C Docking Station",
                    ImageUrl = "https://example.com/images/usb-c-dock.jpg",
                    Price = 2499.50m,
                    DescriptionOfProduct = "Multi-port USB-C docking station with HDMI, Ethernet, and SD card reader.",
                    QuatityStock = 120
                },
                new Infrastructure.Models.PRO_Product
                {
                    ProductName = "Noise Cancelling Headphones",
                    ImageUrl = "https://example.com/images/noise-cancelling-headphones.jpg",
                    Price = 3499.00m,
                    DescriptionOfProduct = "Wireless over-ear headphones with active noise cancellation and 30-hour battery life.",
                    QuatityStock = 60
                },
                new Infrastructure.Models.PRO_Product
                {
                    ProductName = "Bluetooth Speaker",
                    ImageUrl = "https://example.com/images/bluetooth-speaker.jpg",
                    Price = 899.00m,
                    DescriptionOfProduct = "Portable Bluetooth speaker with deep bass and 12-hour playtime.",
                    QuatityStock = 200
                },
                new Infrastructure.Models.PRO_Product
                {
                    ProductName = "Webcam 1080p",
                    ImageUrl = "https://example.com/images/webcam-1080p.jpg",
                    Price = 1299.00m,
                    DescriptionOfProduct = "Full HD webcam with built-in microphone and privacy cover.",
                    QuatityStock = 75
                },
                new Infrastructure.Models.PRO_Product
                {
                    ProductName = "Gaming Chair",
                    ImageUrl = "https://example.com/images/gaming-chair.jpg",
                    Price = 4999.00m,
                    DescriptionOfProduct = "Ergonomic gaming chair with adjustable armrests and lumbar support.",
                    QuatityStock = 30
                },
                new Infrastructure.Models.PRO_Product
                {
                    ProductName = "External SSD 1TB",
                    ImageUrl = "https://example.com/images/external-ssd.jpg",
                    Price = 2999.00m,
                    DescriptionOfProduct = "High-speed portable SSD with USB-C connectivity.",
                    QuatityStock = 90
                },
                new Infrastructure.Models.PRO_Product
                {
                    ProductName = "Smartwatch",
                    ImageUrl = "https://example.com/images/smartwatch.jpg",
                    Price = 3999.00m,
                    DescriptionOfProduct = "Water-resistant smartwatch with heart rate monitor and GPS.",
                    QuatityStock = 110
                },
                new Infrastructure.Models.PRO_Product
                {
                    ProductName = "Wireless Earbuds",
                    ImageUrl = "https://example.com/images/wireless-earbuds.jpg",
                    Price = 1499.00m,
                    DescriptionOfProduct = "True wireless earbuds with charging case and touch controls.",
                    QuatityStock = 180
                },
                new Infrastructure.Models.PRO_Product
                {
                    ProductName = "Laptop Stand",
                    ImageUrl = "https://example.com/images/laptop-stand.jpg",
                    Price = 599.00m,
                    DescriptionOfProduct = "Adjustable aluminum laptop stand for better ergonomics.",
                    QuatityStock = 140
                },
                new Infrastructure.Models.PRO_Product
                {
                    ProductName = "4-Port USB Hub",
                    ImageUrl = "https://example.com/images/usb-hub.jpg",
                    Price = 299.00m,
                    DescriptionOfProduct = "Compact USB 3.0 hub with four ports and fast data transfer.",
                    QuatityStock = 250
                },
                new Infrastructure.Models.PRO_Product
                {
                    ProductName = "Wireless Charger",
                    ImageUrl = "https://example.com/images/wireless-charger.jpg",
                    Price = 799.00m,
                    DescriptionOfProduct = "Fast wireless charging pad compatible with Qi-enabled devices.",
                    QuatityStock = 160
                },
                new Infrastructure.Models.PRO_Product
                {
                    ProductName = "Action Camera",
                    ImageUrl = "https://example.com/images/action-camera.jpg",
                    Price = 2499.00m,
                    DescriptionOfProduct = "Waterproof action camera with 4K recording and wide-angle lens.",
                    QuatityStock = 55
                },
                new Infrastructure.Models.PRO_Product
                {
                    ProductName = "Graphic Tablet",
                    ImageUrl = "https://example.com/images/graphic-tablet.jpg",
                    Price = 1899.00m,
                    DescriptionOfProduct = "Digital drawing tablet with pressure-sensitive stylus.",
                    QuatityStock = 70
                },
                new Infrastructure.Models.PRO_Product
                {
                    ProductName = "Portable Projector",
                    ImageUrl = "https://example.com/images/portable-projector.jpg",
                    Price = 3999.00m,
                    DescriptionOfProduct = "Mini projector with HDMI input and built-in speaker.",
                    QuatityStock = 35
                },
                new Infrastructure.Models.PRO_Product
                {
                    ProductName = "Fitness Tracker",
                    ImageUrl = "https://example.com/images/fitness-tracker.jpg",
                    Price = 999.00m,
                    DescriptionOfProduct = "Fitness tracker with sleep monitoring and step counter.",
                    QuatityStock = 130
                },
                new Infrastructure.Models.PRO_Product
                {
                    ProductName = "Smart Light Bulb",
                    ImageUrl = "https://example.com/images/smart-light-bulb.jpg",
                    Price = 399.00m,
                    DescriptionOfProduct = "Wi-Fi enabled smart bulb with adjustable color and brightness.",
                    QuatityStock = 300
                },
                new Infrastructure.Models.PRO_Product
                {
                    ProductName = "VR Headset",
                    ImageUrl = "https://example.com/images/vr-headset.jpg",
                    Price = 7999.00m,
                    DescriptionOfProduct = "Virtual reality headset with motion controllers.",
                    QuatityStock = 25
                },
                new Infrastructure.Models.PRO_Product
                {
                    ProductName = "Portable Power Bank",
                    ImageUrl = "https://example.com/images/power-bank.jpg",
                    Price = 699.00m,
                    DescriptionOfProduct = "10,000mAh portable power bank with fast charging.",
                    QuatityStock = 220
                },
                new Infrastructure.Models.PRO_Product
                {
                    ProductName = "Smart Plug",
                    ImageUrl = "https://example.com/images/smart-plug.jpg",
                    Price = 349.00m,
                    DescriptionOfProduct = "Wi-Fi smart plug for remote control of appliances.",
                    QuatityStock = 180
                },
                new Infrastructure.Models.PRO_Product
                {
                    ProductName = "Gaming Mouse Pad",
                    ImageUrl = "https://example.com/images/gaming-mouse-pad.jpg",
                    Price = 299.00m,
                    DescriptionOfProduct = "Large gaming mouse pad with non-slip base.",
                    QuatityStock = 210
                },
                new Infrastructure.Models.PRO_Product
                {
                    ProductName = "USB Microphone",
                    ImageUrl = "https://example.com/images/usb-microphone.jpg",
                    Price = 1299.00m,
                    DescriptionOfProduct = "Studio-quality USB microphone for streaming and recording.",
                    QuatityStock = 65
                },
                new Infrastructure.Models.PRO_Product
                {
                    ProductName = "Laptop Backpack",
                    ImageUrl = "https://example.com/images/laptop-backpack.jpg",
                    Price = 999.00m,
                    DescriptionOfProduct = "Water-resistant backpack with padded laptop compartment.",
                    QuatityStock = 95
                },
                new Infrastructure.Models.PRO_Product
                {
                    ProductName = "Smart Thermostat",
                    ImageUrl = "https://example.com/images/smart-thermostat.jpg",
                    Price = 2499.00m,
                    DescriptionOfProduct = "Programmable smart thermostat with Wi-Fi connectivity.",
                    QuatityStock = 50
                },
                new Infrastructure.Models.PRO_Product
                {
                    ProductName = "Streaming Stick",
                    ImageUrl = "https://example.com/images/streaming-stick.jpg",
                    Price = 1199.00m,
                    DescriptionOfProduct = "HDMI streaming stick for TV with voice remote.",
                    QuatityStock = 85
                },
                new Infrastructure.Models.PRO_Product
                {
                    ProductName = "Wireless Presenter",
                    ImageUrl = "https://example.com/images/wireless-presenter.jpg",
                    Price = 499.00m,
                    DescriptionOfProduct = "Wireless presenter with laser pointer and USB receiver.",
                    QuatityStock = 100
                },
                new Infrastructure.Models.PRO_Product
                {
                    ProductName = "Desktop Microphone Arm",
                    ImageUrl = "https://example.com/images/microphone-arm.jpg",
                    Price = 399.00m,
                    DescriptionOfProduct = "Adjustable microphone arm for desk mounting.",
                    QuatityStock = 60
                },
                new Infrastructure.Models.PRO_Product
                {
                    ProductName = "Noise Isolating Earphones",
                    ImageUrl = "https://example.com/images/noise-isolating-earphones.jpg",
                    Price = 799.00m,
                    DescriptionOfProduct = "In-ear earphones with noise isolation and tangle-free cable.",
                    QuatityStock = 170
                },
                new Infrastructure.Models.PRO_Product
                {
                    ProductName = "Smart Doorbell",
                    ImageUrl = "https://example.com/images/smart-doorbell.jpg",
                    Price = 1999.00m,
                    DescriptionOfProduct = "Video doorbell with motion detection and two-way audio.",
                    QuatityStock = 45
                },
                new Infrastructure.Models.PRO_Product
                {
                    ProductName = "USB Desk Fan",
                    ImageUrl = "https://example.com/images/usb-desk-fan.jpg",
                    Price = 299.00m,
                    DescriptionOfProduct = "Compact USB-powered desk fan with adjustable speed.",
                    QuatityStock = 130
                },
                new Infrastructure.Models.PRO_Product
                {
                    ProductName = "Wireless Gaming Controller",
                    ImageUrl = "https://example.com/images/wireless-controller.jpg",
                    Price = 1599.00m,
                    DescriptionOfProduct = "Bluetooth gaming controller compatible with PC and mobile.",
                    QuatityStock = 75
                },
                new Infrastructure.Models.PRO_Product
                {
                    ProductName = "Smart Scale",
                    ImageUrl = "https://example.com/images/smart-scale.jpg",
                    Price = 899.00m,
                    DescriptionOfProduct = "Digital smart scale with body composition analysis.",
                    QuatityStock = 90
                },
                new Infrastructure.Models.PRO_Product
                {
                    ProductName = "LED Desk Lamp",
                    ImageUrl = "https://example.com/images/led-desk-lamp.jpg",
                    Price = 499.00m,
                    DescriptionOfProduct = "Dimmable LED desk lamp with USB charging port.",
                    QuatityStock = 160
                },
                new Infrastructure.Models.PRO_Product
                {
                    ProductName = "Bluetooth Tracker",
                    ImageUrl = "https://example.com/images/bluetooth-tracker.jpg",
                    Price = 399.00m,
                    DescriptionOfProduct = "Bluetooth tracker for keys, wallet, and other valuables.",
                    QuatityStock = 210
                },
                new Infrastructure.Models.PRO_Product
                {
                    ProductName = "Smart Coffee Maker",
                    ImageUrl = "https://example.com/images/smart-coffee-maker.jpg",
                    Price = 2999.00m,
                    DescriptionOfProduct = "Wi-Fi enabled coffee maker with programmable brewing.",
                    QuatityStock = 40
                },
                new Infrastructure.Models.PRO_Product
                {
                    ProductName = "USB-C to HDMI Adapter",
                    ImageUrl = "https://example.com/images/usb-c-hdmi.jpg",
                    Price = 349.00m,
                    DescriptionOfProduct = "USB-C to HDMI adapter for laptops and tablets.",
                    QuatityStock = 180
                },
                new Infrastructure.Models.PRO_Product
                {
                    ProductName = "Wireless Security Camera",
                    ImageUrl = "https://example.com/images/security-camera.jpg",
                    Price = 2499.00m,
                    DescriptionOfProduct = "Wireless security camera with night vision and cloud storage.",
                    QuatityStock = 55
                },
                new Infrastructure.Models.PRO_Product
                {
                    ProductName = "Smart Air Purifier",
                    ImageUrl = "https://example.com/images/air-purifier.jpg",
                    Price = 3499.00m,
                    DescriptionOfProduct = "Smart air purifier with HEPA filter and app control.",
                    QuatityStock = 35
                },
                new Infrastructure.Models.PRO_Product
                {
                    ProductName = "Wireless Charging Mouse Pad",
                    ImageUrl = "https://example.com/images/charging-mouse-pad.jpg",
                    Price = 999.00m,
                    DescriptionOfProduct = "Mouse pad with built-in wireless charging for smartphones.",
                    QuatityStock = 120
                },
                new Infrastructure.Models.PRO_Product
                {
                    ProductName = "Smart Water Bottle",
                    ImageUrl = "https://example.com/images/smart-water-bottle.jpg",
                    Price = 799.00m,
                    DescriptionOfProduct = "Smart water bottle with hydration reminders and LED display.",
                    QuatityStock = 100
                },
                new Infrastructure.Models.PRO_Product
                {
                    ProductName = "USB LED Strip",
                    ImageUrl = "https://example.com/images/usb-led-strip.jpg",
                    Price = 299.00m,
                    DescriptionOfProduct = "Flexible USB-powered LED strip for ambient lighting.",
                    QuatityStock = 200
                },
                new Infrastructure.Models.PRO_Product
                {
                    ProductName = "Smart Wi-Fi Router",
                    ImageUrl = "https://example.com/images/smart-router.jpg",
                    Price = 2499.00m,
                    DescriptionOfProduct = "Dual-band smart Wi-Fi router with parental controls.",
                    QuatityStock = 60
                },
                new Infrastructure.Models.PRO_Product
                {
                    ProductName = "Wireless Barcode Scanner",
                    ImageUrl = "https://example.com/images/barcode-scanner.jpg",
                    Price = 1499.00m,
                    DescriptionOfProduct = "Bluetooth barcode scanner for inventory management.",
                    QuatityStock = 80
                },
                new Infrastructure.Models.PRO_Product
                {
                    ProductName = "Smart TV Box",
                    ImageUrl = "https://example.com/images/smart-tv-box.jpg",
                    Price = 1999.00m,
                    DescriptionOfProduct = "Android smart TV box with 4K streaming support.",
                    QuatityStock = 70
                },
                new Infrastructure.Models.PRO_Product
                {
                    ProductName = "Wireless HDMI Transmitter",
                    ImageUrl = "https://example.com/images/hdmi-transmitter.jpg",
                    Price = 3499.00m,
                    DescriptionOfProduct = "Wireless HDMI transmitter and receiver kit for TVs.",
                    QuatityStock = 30
                },
                new Infrastructure.Models.PRO_Product
                {
                    ProductName = "Smart Alarm Clock",
                    ImageUrl = "https://example.com/images/smart-alarm-clock.jpg",
                    Price = 899.00m,
                    DescriptionOfProduct = "Smart alarm clock with sunrise simulation and Bluetooth speaker.",
                    QuatityStock = 90
                },
                new Infrastructure.Models.PRO_Product
                {
                    ProductName = "USB-C Multiport Adapter",
                    ImageUrl = "https://example.com/images/usb-c-multiport.jpg",
                    Price = 1299.00m,
                    DescriptionOfProduct = "USB-C multiport adapter with HDMI, USB, and SD card slots.",
                    QuatityStock = 110
                },
                new Infrastructure.Models.PRO_Product
                {
                    ProductName = "Smart Home Hub",
                    ImageUrl = "https://example.com/images/smart-home-hub.jpg",
                    Price = 2999.00m,
                    DescriptionOfProduct = "Central smart home hub for device automation and control.",
                    QuatityStock = 50
                }
            };
            return new List<Infrastructure.Models.PRO_Product>
            {
                new Infrastructure.Models.PRO_Product
                {
                    Id = 1,
                    ProductName = "Wireless Mouse",
                    ImageUrl = "https://example.com/images/wireless-mouse.jpg",
                    Price = 499.99m,
                    DescriptionOfProduct = "A comfortable wireless mouse with ergonomic design and long battery life.",
                    QuatityStock = 150
                },
                new Infrastructure.Models.PRO_Product
                {
                    Id = 2,
                    ProductName = "Mechanical Keyboard",
                    ImageUrl = "https://example.com/images/mechanical-keyboard.jpg",
                    Price = 1599.00m,
                    DescriptionOfProduct = "RGB backlit mechanical keyboard with blue switches and detachable wrist rest.",
                    QuatityStock = 80
                },
                new Infrastructure.Models.PRO_Product
                {
                    Id = 3,
                    ProductName = "27\" 4K Monitor",
                    ImageUrl = "https://example.com/images/4k-monitor.jpg",
                    Price = 7999.00m,
                    DescriptionOfProduct = "Ultra HD 4K monitor with IPS panel and adjustable stand.",
                    QuatityStock = 40
                },
                new Infrastructure.Models.PRO_Product
                {
                    Id = 4,
                    ProductName = "USB-C Docking Station",
                    ImageUrl = "https://example.com/images/usb-c-dock.jpg",
                    Price = 2499.50m,
                    DescriptionOfProduct = "Multi-port USB-C docking station with HDMI, Ethernet, and SD card reader.",
                    QuatityStock = 120
                },
                new Infrastructure.Models.PRO_Product
                {
                    Id = 5,
                    ProductName = "Noise Cancelling Headphones",
                    ImageUrl = "https://example.com/images/noise-cancelling-headphones.jpg",
                    Price = 3499.00m,
                    DescriptionOfProduct = "Wireless over-ear headphones with active noise cancellation and 30-hour battery life.",
                    QuatityStock = 60
                },
                new Infrastructure.Models.PRO_Product
                {
                    Id = 6,
                    ProductName = "Bluetooth Speaker",
                    ImageUrl = "https://example.com/images/bluetooth-speaker.jpg",
                    Price = 899.00m,
                    DescriptionOfProduct = "Portable Bluetooth speaker with deep bass and 12-hour playtime.",
                    QuatityStock = 200
                },
                new Infrastructure.Models.PRO_Product
                {
                    Id = 7,
                    ProductName = "Webcam 1080p",
                    ImageUrl = "https://example.com/images/webcam-1080p.jpg",
                    Price = 1299.00m,
                    DescriptionOfProduct = "Full HD webcam with built-in microphone and privacy cover.",
                    QuatityStock = 75
                },
                new Infrastructure.Models.PRO_Product
                {
                    Id = 8,
                    ProductName = "Gaming Chair",
                    ImageUrl = "https://example.com/images/gaming-chair.jpg",
                    Price = 4999.00m,
                    DescriptionOfProduct = "Ergonomic gaming chair with adjustable armrests and lumbar support.",
                    QuatityStock = 30
                },
                new Infrastructure.Models.PRO_Product
                {
                    Id = 9,
                    ProductName = "External SSD 1TB",
                    ImageUrl = "https://example.com/images/external-ssd.jpg",
                    Price = 2999.00m,
                    DescriptionOfProduct = "High-speed portable SSD with USB-C connectivity.",
                    QuatityStock = 90
                },
                new Infrastructure.Models.PRO_Product
                {
                    Id = 10,
                    ProductName = "Smartwatch",
                    ImageUrl = "https://example.com/images/smartwatch.jpg",
                    Price = 3999.00m,
                    DescriptionOfProduct = "Water-resistant smartwatch with heart rate monitor and GPS.",
                    QuatityStock = 110
                },
                new Infrastructure.Models.PRO_Product
                {
                    Id = 11,
                    ProductName = "Wireless Earbuds",
                    ImageUrl = "https://example.com/images/wireless-earbuds.jpg",
                    Price = 1499.00m,
                    DescriptionOfProduct = "True wireless earbuds with charging case and touch controls.",
                    QuatityStock = 180
                },
                new Infrastructure.Models.PRO_Product
                {
                    Id = 12,
                    ProductName = "Laptop Stand",
                    ImageUrl = "https://example.com/images/laptop-stand.jpg",
                    Price = 599.00m,
                    DescriptionOfProduct = "Adjustable aluminum laptop stand for better ergonomics.",
                    QuatityStock = 140
                },
                new Infrastructure.Models.PRO_Product
                {
                    Id = 13,
                    ProductName = "4-Port USB Hub",
                    ImageUrl = "https://example.com/images/usb-hub.jpg",
                    Price = 299.00m,
                    DescriptionOfProduct = "Compact USB 3.0 hub with four ports and fast data transfer.",
                    QuatityStock = 250
                },
                new Infrastructure.Models.PRO_Product
                {
                    Id = 14,
                    ProductName = "Wireless Charger",
                    ImageUrl = "https://example.com/images/wireless-charger.jpg",
                    Price = 799.00m,
                    DescriptionOfProduct = "Fast wireless charging pad compatible with Qi-enabled devices.",
                    QuatityStock = 160
                },
                new Infrastructure.Models.PRO_Product
                {
                    Id = 15,
                    ProductName = "Action Camera",
                    ImageUrl = "https://example.com/images/action-camera.jpg",
                    Price = 2499.00m,
                    DescriptionOfProduct = "Waterproof action camera with 4K recording and wide-angle lens.",
                    QuatityStock = 55
                },
                new Infrastructure.Models.PRO_Product
                {
                    Id = 16,
                    ProductName = "Graphic Tablet",
                    ImageUrl = "https://example.com/images/graphic-tablet.jpg",
                    Price = 1899.00m,
                    DescriptionOfProduct = "Digital drawing tablet with pressure-sensitive stylus.",
                    QuatityStock = 70
                },
                new Infrastructure.Models.PRO_Product
                {
                    Id = 17,
                    ProductName = "Portable Projector",
                    ImageUrl = "https://example.com/images/portable-projector.jpg",
                    Price = 3999.00m,
                    DescriptionOfProduct = "Mini projector with HDMI input and built-in speaker.",
                    QuatityStock = 35
                },
                new Infrastructure.Models.PRO_Product
                {
                    Id = 18,
                    ProductName = "Fitness Tracker",
                    ImageUrl = "https://example.com/images/fitness-tracker.jpg",
                    Price = 999.00m,
                    DescriptionOfProduct = "Fitness tracker with sleep monitoring and step counter.",
                    QuatityStock = 130
                },
                new Infrastructure.Models.PRO_Product
                {
                    Id = 19,
                    ProductName = "Smart Light Bulb",
                    ImageUrl = "https://example.com/images/smart-light-bulb.jpg",
                    Price = 399.00m,
                    DescriptionOfProduct = "Wi-Fi enabled smart bulb with adjustable color and brightness.",
                    QuatityStock = 300
                },
                new Infrastructure.Models.PRO_Product
                {
                    Id = 20,
                    ProductName = "VR Headset",
                    ImageUrl = "https://example.com/images/vr-headset.jpg",
                    Price = 7999.00m,
                    DescriptionOfProduct = "Virtual reality headset with motion controllers.",
                    QuatityStock = 25
                },
                new Infrastructure.Models.PRO_Product
                {
                    Id = 21,
                    ProductName = "Portable Power Bank",
                    ImageUrl = "https://example.com/images/power-bank.jpg",
                    Price = 699.00m,
                    DescriptionOfProduct = "10,000mAh portable power bank with fast charging.",
                    QuatityStock = 220
                },
                new Infrastructure.Models.PRO_Product
                {
                    Id = 22,
                    ProductName = "Smart Plug",
                    ImageUrl = "https://example.com/images/smart-plug.jpg",
                    Price = 349.00m,
                    DescriptionOfProduct = "Wi-Fi smart plug for remote control of appliances.",
                    QuatityStock = 180
                },
                new Infrastructure.Models.PRO_Product
                {
                    Id = 23,
                    ProductName = "Gaming Mouse Pad",
                    ImageUrl = "https://example.com/images/gaming-mouse-pad.jpg",
                    Price = 299.00m,
                    DescriptionOfProduct = "Large gaming mouse pad with non-slip base.",
                    QuatityStock = 210
                },
                new Infrastructure.Models.PRO_Product
                {
                    Id = 24,
                    ProductName = "USB Microphone",
                    ImageUrl = "https://example.com/images/usb-microphone.jpg",
                    Price = 1299.00m,
                    DescriptionOfProduct = "Studio-quality USB microphone for streaming and recording.",
                    QuatityStock = 65
                },
                new Infrastructure.Models.PRO_Product
                {
                    Id = 25,
                    ProductName = "Laptop Backpack",
                    ImageUrl = "https://example.com/images/laptop-backpack.jpg",
                    Price = 999.00m,
                    DescriptionOfProduct = "Water-resistant backpack with padded laptop compartment.",
                    QuatityStock = 95
                },
                new Infrastructure.Models.PRO_Product
                {
                    Id = 26,
                    ProductName = "Smart Thermostat",
                    ImageUrl = "https://example.com/images/smart-thermostat.jpg",
                    Price = 2499.00m,
                    DescriptionOfProduct = "Programmable smart thermostat with Wi-Fi connectivity.",
                    QuatityStock = 50
                },
                new Infrastructure.Models.PRO_Product
                {
                    Id = 27,
                    ProductName = "Streaming Stick",
                    ImageUrl = "https://example.com/images/streaming-stick.jpg",
                    Price = 1199.00m,
                    DescriptionOfProduct = "HDMI streaming stick for TV with voice remote.",
                    QuatityStock = 85
                },
                new Infrastructure.Models.PRO_Product
                {
                    Id = 28,
                    ProductName = "Wireless Presenter",
                    ImageUrl = "https://example.com/images/wireless-presenter.jpg",
                    Price = 499.00m,
                    DescriptionOfProduct = "Wireless presenter with laser pointer and USB receiver.",
                    QuatityStock = 100
                },
                new Infrastructure.Models.PRO_Product
                {
                    Id = 29,
                    ProductName = "Desktop Microphone Arm",
                    ImageUrl = "https://example.com/images/microphone-arm.jpg",
                    Price = 399.00m,
                    DescriptionOfProduct = "Adjustable microphone arm for desk mounting.",
                    QuatityStock = 60
                },
                new Infrastructure.Models.PRO_Product
                {
                    Id = 30,
                    ProductName = "Noise Isolating Earphones",
                    ImageUrl = "https://example.com/images/noise-isolating-earphones.jpg",
                    Price = 799.00m,
                    DescriptionOfProduct = "In-ear earphones with noise isolation and tangle-free cable.",
                    QuatityStock = 170
                },
                new Infrastructure.Models.PRO_Product
                {
                    Id = 31,
                    ProductName = "Smart Doorbell",
                    ImageUrl = "https://example.com/images/smart-doorbell.jpg",
                    Price = 1999.00m,
                    DescriptionOfProduct = "Video doorbell with motion detection and two-way audio.",
                    QuatityStock = 45
                },
                new Infrastructure.Models.PRO_Product
                {
                    Id = 32,
                    ProductName = "USB Desk Fan",
                    ImageUrl = "https://example.com/images/usb-desk-fan.jpg",
                    Price = 299.00m,
                    DescriptionOfProduct = "Compact USB-powered desk fan with adjustable speed.",
                    QuatityStock = 130
                },
                new Infrastructure.Models.PRO_Product
                {
                    Id = 33,
                    ProductName = "Wireless Gaming Controller",
                    ImageUrl = "https://example.com/images/wireless-controller.jpg",
                    Price = 1599.00m,
                    DescriptionOfProduct = "Bluetooth gaming controller compatible with PC and mobile.",
                    QuatityStock = 75
                },
                new Infrastructure.Models.PRO_Product
                {
                    Id = 34,
                    ProductName = "Smart Scale",
                    ImageUrl = "https://example.com/images/smart-scale.jpg",
                    Price = 899.00m,
                    DescriptionOfProduct = "Digital smart scale with body composition analysis.",
                    QuatityStock = 90
                },
                new Infrastructure.Models.PRO_Product
                {
                    Id = 35,
                    ProductName = "LED Desk Lamp",
                    ImageUrl = "https://example.com/images/led-desk-lamp.jpg",
                    Price = 499.00m,
                    DescriptionOfProduct = "Dimmable LED desk lamp with USB charging port.",
                    QuatityStock = 160
                },
                new Infrastructure.Models.PRO_Product
                {
                    Id = 36,
                    ProductName = "Bluetooth Tracker",
                    ImageUrl = "https://example.com/images/bluetooth-tracker.jpg",
                    Price = 399.00m,
                    DescriptionOfProduct = "Bluetooth tracker for keys, wallet, and other valuables.",
                    QuatityStock = 210
                },
                new Infrastructure.Models.PRO_Product
                {
                    Id = 37,
                    ProductName = "Smart Coffee Maker",
                    ImageUrl = "https://example.com/images/smart-coffee-maker.jpg",
                    Price = 2999.00m,
                    DescriptionOfProduct = "Wi-Fi enabled coffee maker with programmable brewing.",
                    QuatityStock = 40
                },
                new Infrastructure.Models.PRO_Product
                {
                    Id = 38,
                    ProductName = "USB-C to HDMI Adapter",
                    ImageUrl = "https://example.com/images/usb-c-hdmi.jpg",
                    Price = 349.00m,
                    DescriptionOfProduct = "USB-C to HDMI adapter for laptops and tablets.",
                    QuatityStock = 180
                },
                new Infrastructure.Models.PRO_Product
                {
                    Id = 39,
                    ProductName = "Wireless Security Camera",
                    ImageUrl = "https://example.com/images/security-camera.jpg",
                    Price = 2499.00m,
                    DescriptionOfProduct = "Wireless security camera with night vision and cloud storage.",
                    QuatityStock = 55
                },
                new Infrastructure.Models.PRO_Product
                {
                    Id = 40,
                    ProductName = "Smart Air Purifier",
                    ImageUrl = "https://example.com/images/air-purifier.jpg",
                    Price = 3499.00m,
                    DescriptionOfProduct = "Smart air purifier with HEPA filter and app control.",
                    QuatityStock = 35
                },
                new Infrastructure.Models.PRO_Product
                {
                    Id = 41,
                    ProductName = "Wireless Charging Mouse Pad",
                    ImageUrl = "https://example.com/images/charging-mouse-pad.jpg",
                    Price = 999.00m,
                    DescriptionOfProduct = "Mouse pad with built-in wireless charging for smartphones.",
                    QuatityStock = 120
                },
                new Infrastructure.Models.PRO_Product
                {
                    Id = 42,
                    ProductName = "Smart Water Bottle",
                    ImageUrl = "https://example.com/images/smart-water-bottle.jpg",
                    Price = 799.00m,
                    DescriptionOfProduct = "Smart water bottle with hydration reminders and LED display.",
                    QuatityStock = 100
                },
                new Infrastructure.Models.PRO_Product
                {
                    Id = 43,
                    ProductName = "USB LED Strip",
                    ImageUrl = "https://example.com/images/usb-led-strip.jpg",
                    Price = 299.00m,
                    DescriptionOfProduct = "Flexible USB-powered LED strip for ambient lighting.",
                    QuatityStock = 200
                },
                new Infrastructure.Models.PRO_Product
                {
                    Id = 44,
                    ProductName = "Smart Wi-Fi Router",
                    ImageUrl = "https://example.com/images/smart-router.jpg",
                    Price = 2499.00m,
                    DescriptionOfProduct = "Dual-band smart Wi-Fi router with parental controls.",
                    QuatityStock = 60
                },
                new Infrastructure.Models.PRO_Product
                {
                    Id = 45,
                    ProductName = "Wireless Barcode Scanner",
                    ImageUrl = "https://example.com/images/barcode-scanner.jpg",
                    Price = 1499.00m,
                    DescriptionOfProduct = "Bluetooth barcode scanner for inventory management.",
                    QuatityStock = 80
                },
                new Infrastructure.Models.PRO_Product
                {
                    Id = 46,
                    ProductName = "Smart TV Box",
                    ImageUrl = "https://example.com/images/smart-tv-box.jpg",
                    Price = 1999.00m,
                    DescriptionOfProduct = "Android smart TV box with 4K streaming support.",
                    QuatityStock = 70
                },
                new Infrastructure.Models.PRO_Product
                {
                    Id = 47,
                    ProductName = "Wireless HDMI Transmitter",
                    ImageUrl = "https://example.com/images/hdmi-transmitter.jpg",
                    Price = 3499.00m,
                    DescriptionOfProduct = "Wireless HDMI transmitter and receiver kit for TVs.",
                    QuatityStock = 30
                },
                new Infrastructure.Models.PRO_Product
                {
                    Id = 48,
                    ProductName = "Smart Alarm Clock",
                    ImageUrl = "https://example.com/images/smart-alarm-clock.jpg",
                    Price = 899.00m,
                    DescriptionOfProduct = "Smart alarm clock with sunrise simulation and Bluetooth speaker.",
                    QuatityStock = 90
                },
                new Infrastructure.Models.PRO_Product
                {
                    Id = 49,
                    ProductName = "USB-C Multiport Adapter",
                    ImageUrl = "https://example.com/images/usb-c-multiport.jpg",
                    Price = 1299.00m,
                    DescriptionOfProduct = "USB-C multiport adapter with HDMI, USB, and SD card slots.",
                    QuatityStock = 110
                },
                new Infrastructure.Models.PRO_Product
                {
                    Id = 50,
                    ProductName = "Smart Home Hub",
                    ImageUrl = "https://example.com/images/smart-home-hub.jpg",
                    Price = 2999.00m,
                    DescriptionOfProduct = "Central smart home hub for device automation and control.",
                    QuatityStock = 50
                }
            };
        }
    }
}
