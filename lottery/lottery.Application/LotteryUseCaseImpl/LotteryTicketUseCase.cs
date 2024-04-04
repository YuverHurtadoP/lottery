using lottery.Application.InterfaceLotteryUseCase;
using lottery.Domain.Repository;
using lottery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lottery.Application.LotteryUseCaseImpl
{
    public class LotteryTicketUseCase : ILotteryTicketUseCase
    {

    private readonly IGenericRepository<Ticket> _genericRepository;
    private readonly IGenericRepository<Product> _genericProduct;
    // Objeto Random para generar números aleatorios
    private static readonly Random random = new Random();

    public LotteryTicketUseCase(IGenericRepository<Ticket> genericRepository)
    {
      _genericRepository = genericRepository;
       
    }
    public string AddTicket(int idProduct)
    {
      try
      {
       
        if (_genericRepository.Exists(idProduct))
        {
          Ticket entity = new Ticket();

          string ticketNumber = GenerateLotteryNumber();
          entity.ProductId = idProduct;
          entity.Number = int.Parse(ticketNumber);

          _genericRepository.AddInformation(entity);
          return ticketNumber;
        }
        else
        {
          return "El id del producto no existe en la base de datos";
        }
      }
      catch (Exception ex)
      {
        // Manejar la excepción
        return "El id del producto no existe en la base de datos";
      }
    }


    // Método para generar un número de lotería válido
    private string GenerateLotteryNumber()
    {
      string lotteryNumber;
      do
      {
        // Generar un número aleatorio de 5 dígitos
        lotteryNumber = GenerateRandomNumber();
      } while (ContainsMoreThanThreeConsecutiveDigits(lotteryNumber)); // Verificar si el número generado cumple con los requisitos

      return lotteryNumber; // Devolver el número de lotería generado
    }

    // Método para generar un número aleatorio de 5 dígitos
    // Método para generar un número aleatorio de 5 dígitos
    private string GenerateRandomNumber()
    {
      int randomNumber = random.Next(0, 99999); // Generar un número aleatorio dentro del rango especificado
      string formattedNumber = randomNumber.ToString("D5"); // Convertir el número a una cadena de 5 caracteres, agregando ceros a la izquierda si es necesario
      return formattedNumber;
    }

    // Método para verificar si un número contiene más de 3 dígitos consecutivos iguales
    private bool ContainsMoreThanThreeConsecutiveDigits(string number)
    {
      Ticket entity = _genericRepository.FindByProperty(x => x.Number == int.Parse(number));
      if(entity == null) {
        for (int i = 0; i < number.Length - 3; i++)
        {
          // Verificar si hay más de 3 dígitos iguales consecutivos
          if (number[i] == number[i + 1] && number[i] == number[i + 2] && number[i] == number[i + 3])
          {
            return true; // Devolver true si se encuentra más de 3 dígitos iguales consecutivos
          }
        }
        return false; // Devolver false si no se encuentra más de 3 dígitos iguales consecutivos
      }
      else
      {
        return true; // Devolver false si no se encuentra más de 3 dígitos iguales consecutivos

      }
   
    
    }
  }
}
