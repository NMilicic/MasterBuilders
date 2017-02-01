//
//  CustomViewCell.swift
//  LegoApp
//
//  Created by Helena Tamburić on 21/01/2017.
//  Copyright © 2017 Helena Tamburić. All rights reserved.
//

import UIKit
import Alamofire
import SVProgressHUD
import Unbox

class CustomViewCell: UITableViewCell {
    //sets
    @IBOutlet weak var id: UILabel!
    
    @IBOutlet weak var idbuilder: UILabel!
    
    @IBOutlet weak var idwishes: UILabel!
  
    @IBOutlet weak var idinventory: UILabel!
    
    @IBOutlet weak var noOfParts: UILabel!
    
    @IBOutlet weak var instructionsSets: UILabel!
    @IBOutlet weak var year: UILabel!
    
    @IBOutlet weak var photo: UIImageView!
    
    @IBOutlet weak var name: UILabel!
    
    @IBOutlet weak var descript: UILabel!
    
    @IBOutlet weak var theme: UILabel!
    
    @IBOutlet weak var quantity: UILabel!
    
    
    
    @IBOutlet weak var fav: UILabel!
    
    @IBOutlet weak var own: UILabel!
    
    @IBOutlet weak var instructionsWishes: UILabel!
    @IBOutlet weak var instructionsBuilder: UILabel!
    
    @IBOutlet weak var instructionsInventory: UILabel!

    
    
    
    public enum HTTPMethod: String {
        case options = "OPTIONS"
        case get     = "GET"
        case head    = "HEAD"
        case post    = "POST"
        case put     = "PUT"
        case patch   = "PATCH"
        case delete  = "DELETE"
        case trace   = "TRACE"
        case connect = "CONNECT"
    }
    
    @IBAction func DeleteOneWishFromWishList(_ sender: Any) {
        let parameters: Parameters  = [
            "UserId": Int(CurrentUser.user)! ,
            "Number": -1,
            "LSetId": idwishes.text!
        ]
       
        ///same method but negative number
        wishSth(parameters: parameters, del: true)
        quantity.text = String (Int(quantity.text!)!-1)
    }
    
    @IBAction func DeleteOneFromInventory(_ sender: Any) {
        let parameters: Parameters  = [
            "UserId": Int(CurrentUser.user)! ,
            "Owned": 1,
            "Built": 0,
            "SetId": idinventory.text!
        ]
        DeleteOneFromInventory(parameters: parameters)
        print("izbrisan jedan")
        
    }
    
    @IBAction func UnmarkAsBuilt(_ sender: Any) {
        let parameters: Parameters  = [
            "UserId": Int(CurrentUser.user)! ,
            "Owned": 0,
            "Built": -1,
            "SetId": idinventory.text!
        ]
        markAsBuilt(parameters: parameters,del: true)
        print("odznacen")
    }
    @IBAction func MarkAsBuilt(_ sender: Any) {
        let parameters: Parameters  = [
            "UserId": Int(CurrentUser.user)! ,
            "Owned": 0,
            "Built": 1,
            "SetId": idinventory.text!
        ]
        markAsBuilt(parameters: parameters, del: false)
        print("oznacen")
    }
    
    @IBAction func InstructionsFromInventory(_ sender: Any) {
           UIApplication.shared.open(URL(string: instructionsInventory.text!)!)
    }
    
    @IBAction func InstructionsFromWishes(_ sender: Any) {
        UIApplication.shared.open(URL(string: instructionsWishes.text!)!)
    }
    @IBAction func InstructionsFromBuilder(_ sender: Any) {
        UIApplication.shared.open(URL(string: instructionsBuilder.text!)!)
    }
    @IBAction func InstructionsFromSets(_ sender: Any) {
        UIApplication.shared.open(URL(string: instructionsSets.text!)!)
    }
    
    @IBAction func PutToInventoryFromWishes(_ sender: Any) {
        
        let parameters: Parameters  = [
            "UserId": Int(CurrentUser.user)! ,
            "Owned": 1,
            "Built": 0,
            "SetId": idwishes.text!
        ]
        
        putToInventory(parameters: parameters)
        //own.text = String (Int(own.text!)!+1)
        

    }
   
    @IBAction func PutToInventoryFromInventory(_ sender: Any) {
        let parameters: Parameters  = [
            "UserId": Int(CurrentUser.user)! ,
            "Owned": 1,
            "Built": 0,
            "SetId": idinventory.text!
        ]
         putToInventory(parameters: parameters)
         own.text = String (Int(own.text!)!+1)
    }
  
    
    //from setsView
    @IBAction func PutToInventory(_ sender: UIButton) {
        
        let parameters: Parameters  = [
            "UserId": Int(CurrentUser.user)! ,
            "Owned": 1,
            "Built": 0,
            "SetId": id.text!
        ]
        putToInventory(parameters: parameters)
        //fail opet nema pristup own sets na inventory
        //own.text = String (Int(own.text!)!+1)
    }
    func DeleteOneFromInventory(parameters: Parameters){
        Alamofire.request("http://mylego.local/api/InventoryApi/RemoveSetsFromInventory", method: .post, parameters: parameters, encoding: JSONEncoding.default, headers: nil).responseJSON { (response:DataResponse<Any>) in
            
            switch(response.result) {
                
            case .success(_):
                
                let statusCode = response.response?.statusCode
                if statusCode==201{
                    SVProgressHUD.showSuccess(withStatus: "Deleted 1 piece")
                    self.own.text = String (Int(self.own.text!)!-1)
                }
                else{
                    print("Tu2")
                    SVProgressHUD.showError(withStatus: "Nema više  setova zato ih nemožete izbrisati")
                    //let storyboard = UIStoryboard(name: "MainStoryboard", bundle: nil)
                }
                
            case .failure(let error):
                print("Tu")
                SVProgressHUD.showError(withStatus: "\(error.localizedDescription)")
            }
            
        }
    }
    
    
    func markAsBuilt(parameters: Parameters, del: Bool){
        Alamofire.request("http://mylego.local/api/InventoryApi/MarkSetsAsCompleted", method: .post, parameters: parameters, encoding: JSONEncoding.default, headers: nil).responseJSON { (response:DataResponse<Any>) in
            
            switch(response.result) {
                
            case .success(_):
                
                let statusCode = response.response?.statusCode
                if statusCode==201{
                    SVProgressHUD.showSuccess(withStatus: "Marked as built")
                    if (del){
                        self.fav.text = String (Int(self.fav.text!)!-1)
                    }
                    else{
                        self.fav.text = String (Int(self.fav.text!)!+1)
                    }
                }
                else{
                    print("Tu2")
                    if (del){
                    SVProgressHUD.showError(withStatus: "Nema više slobodnih setova zato nemožete označiti kao izgrađen")
                    }
                    else{
                        //SVProgressHUD.showError(withStatus: "")
                    }
                    
                }
                
            case .failure(let error):
                print("Tu")
                SVProgressHUD.showError(withStatus: "\(error.localizedDescription)")
            }
            
        }

    
    }
    
    func putToInventory(parameters: Parameters){
        Alamofire.request("http://mylego.local/api/InventoryApi/AddSetsToInventory", method: .post, parameters: parameters, encoding: JSONEncoding.default, headers: nil).responseJSON { (response:DataResponse<Any>) in
            
            switch(response.result) {
                
            case .success(_):
                
                let statusCode = response.response?.statusCode
                if statusCode==201{
                    SVProgressHUD.showSuccess(withStatus: "Added to inventory")
                    //self.own.text = String (Int(self.own.text!)!+1)
                }
                else{
                    print("Tu2")
                    SVProgressHUD.showError(withStatus: "\(statusCode)")
                    //let storyboard = UIStoryboard(name: "MainStoryboard", bundle: nil)
                }
                
            case .failure(let error):
                print("Tu")
                SVProgressHUD.showError(withStatus: "\(error.localizedDescription)")
            }
            
        }

    }
    
    func wishSth(parameters: Parameters, del: Bool){
        Alamofire.request("http://mylego.local/api/WishlistAPi/AddSetsToWishlistForUser", method: .post, parameters: parameters, encoding: JSONEncoding.default, headers: nil).responseJSON { (response:DataResponse<Any>) in
            
            switch(response.result) {
                
            case .success(_):
                
                let statusCode = response.response?.statusCode
                if statusCode==201{
                    if (del){
                        SVProgressHUD.showSuccess(withStatus: "Deleted One Wish")
                        //self.quantity.text = String (Int(self.quantity.text!)!-1)
                    }
                    else{
                        SVProgressHUD.showSuccess(withStatus: "Wished")
                        //self.quantity.text = String (Int(self.quantity.text!)!+1)
                    }
                }
                else{
                    if (del){
                        SVProgressHUD.showError(withStatus: "Dont have more wishes on that set")
                    }
                   
                }
                
            case .failure(let error):
                SVProgressHUD.showError(withStatus: "\(error.localizedDescription)")
            }
            
        }
    }
    
    @IBAction func WishFromWishList(_ sender: Any) {
        
        let parameters: Parameters  = [
            "UserId": Int(CurrentUser.user)! ,
            "Number": 1,
            "LSetId": idwishes.text!
        ]
        wishSth(parameters: parameters, del: false)
        //OK to je unutar njegove forme nema beda
        quantity.text = String (Int(quantity.text!)!+1)
        
       

    }
    
    //novi action
    @IBAction func WishFromInventory(_ sender: Any) {
        let parameters: Parameters  = [
            "UserId": Int(CurrentUser.user)! ,
            "Number": 1,
            "LSetId": idinventory.text!
        ]
        print("zelim iz inventorija")
        wishSth(parameters: parameters, del: false)
        
        //on s ovim pokusava promijenit svoj quantity koj ne postoji u inventory
        // a ja bi da on promjenu naoravi na wishesView
        quantity.text = String (Int( quantity.text!)!+1)
    }
    //stari action- nestala referenca?fake
    @IBAction func WishFromInv(_ sender: UIButton) {
            let parameters: Parameters  = [
                "UserId": Int(CurrentUser.user)! ,
                "Number": 1,
                "LSetId": idinventory.text!
            ]
            print("zelim iz inventorija")
            wishSth(parameters: parameters, del: false)
    }
    
 
    //from setsView
    @IBAction func WishThat(_ sender: UIButton) {
        let parameters: Parameters  = [
            "UserId": Int(CurrentUser.user)! ,
            "Number": 1,
            "LSetId": id.text!
        ]
        
       wishSth(parameters: parameters, del: false)
       //quantity.text = String (Int(quantity.text!)!+1)
        

    }
    
    
    
        
        
    
    
    
    override func awakeFromNib() {
        super.awakeFromNib()
        // Initialization code
    }

    override func setSelected(_ selected: Bool, animated: Bool) {
        super.setSelected(selected, animated: animated)

        // Configure the view for the selected state
       
    }

}
